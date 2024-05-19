namespace Brimborium.Werkzeugkasten.FileLogging;

/// <summary>
/// A provider of <see cref="BatchingLogger"/> instances.
/// </summary>
public abstract class BatchingLoggerProvider : ILoggerProvider, ISupportExternalScope {
    private readonly List<LogMessage> _CurrentBatch = new(1024);
    private readonly TimeSpan _FlushPeriod;
    private readonly int? _QueueSize;
    private readonly int? _BatchSize;
    protected IDisposable? _OptionsChangeToken;

    private int _MessagesDropped;

    private BlockingCollection<LogMessage>? _MessageQueue;
    private Task? _OutputTask;
    private CancellationTokenSource? _StopTokenSource;
    private SemaphoreSlim _SemaphoreProcessMessageQueueWrite = new SemaphoreSlim(1, 1);
    private SemaphoreSlim _SemaphoreProcessMessageQueueIdle = new SemaphoreSlim(1, 1);
    private long _ProcessMessageQueueWatchDog = 10;
    private bool _IncludeScopes;
    private IExternalScopeProvider? _ScopeProvider;

    internal protected IExternalScopeProvider? ScopeProvider => this._IncludeScopes ? this._ScopeProvider : null;

    internal protected bool IncludeScopes => this._IncludeScopes;

    internal protected BatchingLoggerProvider(BatchingLoggerOptions loggerOptions) {
        // NOTE: Only IsEnabled is monitored
        if (loggerOptions.BatchSize <= 0) {
            throw new ArgumentOutOfRangeException(nameof(loggerOptions.BatchSize), $"{nameof(loggerOptions.BatchSize)} must be a positive number.");
        }
        if (loggerOptions.FlushPeriod <= TimeSpan.Zero) {
            throw new ArgumentOutOfRangeException(nameof(loggerOptions.FlushPeriod), $"{nameof(loggerOptions.FlushPeriod)} must be longer than zero.");
        }

        this._FlushPeriod = loggerOptions.FlushPeriod;
        this._BatchSize = loggerOptions.BatchSize;
        this._QueueSize = loggerOptions.BackgroundQueueSize;

        // this._OptionsChangeToken = options.OnChange(this.UpdateOptions);
        // this.UpdateOptions(options.CurrentValue);
    }

    /// <summary>
    /// Checks if the queue is enabled.
    /// </summary>
    public bool IsEnabled { get; private set; }

    public bool UseJSONFormat { get; private set; }

    public bool IncludeEventId { get; private set; }

    public JsonWriterOptions JsonWriterOptions { get; private set; }

    /// <summary>
    /// Gets or sets format string used to format timestamp in logging messages. Defaults to <c>null</c>.
    /// </summary>
    //[StringSyntax(StringSyntaxAttribute.DateTimeFormat)]
    public string? TimestampFormat { get; set; }

    /// <summary>
    /// Gets or sets indication whether or not UTC timezone should be used to format timestamps in logging messages. Defaults to <c>false</c>.
    /// </summary>
    public bool UseUtcTimestamp { get; set; }

    protected void UpdateOptions(BatchingLoggerOptions options) {
        var oldIsEnabled = this.IsEnabled;
        this.UpdateOptionsInternal(options);

        if (oldIsEnabled != this.IsEnabled) {
            if (this.IsEnabled) {
                this.Start();
            } else {
                this.Stop();
            }
        }
    }

    protected virtual void UpdateOptionsInternal(BatchingLoggerOptions options) {
        this.IsEnabled = options.IsLoggerEnabled;
        this.UseJSONFormat = options.UseJSONFormat;
        this.TimestampFormat = options.TimestampFormat;
        this.UseUtcTimestamp = options.UseUtcTimestamp;
        this.IncludeEventId = options.IncludeEventId;
        this.JsonWriterOptions = options.JsonWriterOptions;
        this._IncludeScopes = options.IncludeScopes;
    }

    internal protected abstract Task WriteMessagesAsync(IEnumerable<LogMessage> messages, CancellationToken token);

    private async Task ProcessLogQueue() {
        if (this._StopTokenSource is null) { throw new ArgumentException("_StopTokenSource is null"); }
        if (this._MessageQueue is null) { throw new ArgumentException("_MessageQueue is null"); }

        try {
            this._ProcessMessageQueueWatchDog = 0;
            while (!this._StopTokenSource.IsCancellationRequested) {
                if (await this.FlushAsync(this._StopTokenSource.Token)) {
                    //
                    this._ProcessMessageQueueWatchDog = 10;
                } else {
                    if (this._StopTokenSource.IsCancellationRequested) { return; }
                    this._ProcessMessageQueueWatchDog--;
                    if (this._ProcessMessageQueueWatchDog > 0) {
                        await this.IntervalAsync(this._FlushPeriod, this._StopTokenSource.Token).ConfigureAwait(false);
                    } else {
                        try {
                            await this._SemaphoreProcessMessageQueueIdle.WaitAsync(this._StopTokenSource.Token).ConfigureAwait(false);
                        } catch { }
                    }
                }
            }
        } catch (Exception error) {
            System.Console.Error.WriteLine(error.ToString());
        } finally {
            using (this._StopTokenSource) {
                this._StopTokenSource = null;
            }
        }
    }

    private async Task<bool> FlushAsync(CancellationToken cancellationToken) {
        await this._SemaphoreProcessMessageQueueWrite.WaitAsync();
        try {
            if (!(this._MessageQueue is { } messageQueue)) { return false; }

            var limit = this._BatchSize ?? int.MaxValue;

            while (limit > 0 && messageQueue.TryTake(out var message)) {
                this._CurrentBatch.Add(message);
                limit--;
            }

            var messagesDropped = Interlocked.Exchange(ref this._MessagesDropped, 0);
            if (messagesDropped != 0) {
                this._CurrentBatch.Add(new LogMessage(DateTimeOffset.UtcNow, $"{messagesDropped} message(s) dropped because of queue size limit. Increase the queue size or decrease logging verbosity to avoid this.{Environment.NewLine}"));
            }

            if (this._CurrentBatch.Count > 0) {
                try {
                    await this.WriteMessagesAsync(this._CurrentBatch, cancellationToken).ConfigureAwait(false);
                    this._CurrentBatch.Clear();
                } catch {
                    // ignored
                }
                return true;
            } else {
                return false;
            }
        } finally {
            this._SemaphoreProcessMessageQueueWrite.Release();
        }
    }

    /// <summary>
    /// Wait for the given <see cref="TimeSpan"/>.
    /// </summary>
    /// <param name="interval">The amount of time to wait.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the delay.</param>
    /// <returns>A <see cref="Task"/> which completes when the <paramref name="interval"/> has passed or the <paramref name="cancellationToken"/> has been canceled.</returns>
    protected virtual Task IntervalAsync(TimeSpan interval, CancellationToken cancellationToken) {
        return Task.Delay(interval, cancellationToken);
    }

    internal protected void AddMessage(DateTimeOffset timestamp, string message) {
        if (this._MessageQueue is null) { throw new ArgumentException("_messageQueue is null"); }

        if (!this._MessageQueue.IsAddingCompleted) {
            try {
                if (this._MessageQueue.TryAdd(
                   item: new LogMessage(timestamp, message),
                    millisecondsTimeout: 0,
                    cancellationToken: (this._StopTokenSource is null) ? CancellationToken.None : this._StopTokenSource.Token)) {
                    try {
                        if (this._ProcessMessageQueueWatchDog <= 0
                            && this._SemaphoreProcessMessageQueueIdle.CurrentCount == 0) {
                            this._SemaphoreProcessMessageQueueIdle.Release();
                        }
                    } catch { }
                } else {
                    Interlocked.Increment(ref this._MessagesDropped);
                }
            } catch {
                //cancellation token canceled or CompleteAdding called
            }
        }
    }

    protected void Start() {
        this._MessageQueue = this._QueueSize == null ?
            new BlockingCollection<LogMessage>(new ConcurrentQueue<LogMessage>()) :
            new BlockingCollection<LogMessage>(new ConcurrentQueue<LogMessage>(), this._QueueSize.Value);

        this._StopTokenSource = new CancellationTokenSource();
        this._OutputTask = Task.Run(this.ProcessLogQueue);
    }

    private void Stop() {
        this.FlushAsync(CancellationToken.None).GetAwaiter().GetResult();
        this._StopTokenSource?.Cancel();
        this._MessageQueue?.CompleteAdding();

        try {
            this._OutputTask?.Wait(this._FlushPeriod);
        } catch (TaskCanceledException) {
        } catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is TaskCanceledException) {
        }
    }

    /// <inheritdoc/>
    public void Dispose() {
        this._OptionsChangeToken?.Dispose();
        if (this.IsEnabled) {
            this._MessageQueue?.CompleteAdding();

            try {
                this._OutputTask?.Wait(this._FlushPeriod);
            } catch (TaskCanceledException) {
            } catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is TaskCanceledException) {
            }

            this.Stop();
        }
    }


    public void Flush() {
        this.FlushAsync(CancellationToken.None)
            .GetAwaiter()
            .GetResult();
    }


    /// <summary>
    /// Creates a <see cref="BatchingLogger"/> with the given <paramref name="categoryName"/>.
    /// </summary>
    /// <param name="categoryName">The name of the category to create this logger with.</param>
    /// <returns>The <see cref="BatchingLogger"/> that was created.</returns>
    public ILogger CreateLogger(string categoryName) {
        return new BatchingLogger(this, categoryName);
    }

    /// <summary>
    /// Sets the scope on this provider.
    /// </summary>
    /// <param name="scopeProvider">Provides the scope.</param>
    void ISupportExternalScope.SetScopeProvider(IExternalScopeProvider scopeProvider) {
        this._ScopeProvider = scopeProvider;
    }
}
