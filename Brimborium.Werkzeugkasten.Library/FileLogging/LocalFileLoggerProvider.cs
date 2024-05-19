namespace Brimborium.Werkzeugkasten.FileLogging;

public class LocalFileBaseLoggerProvider<TLocalFileBaseLoggerOptions> : BatchingLoggerProvider 
    where TLocalFileBaseLoggerOptions : LocalFileBaseLoggerOptions {
    private static int __Count = 0;
    private int _Index = 0;
    public string Path = string.Empty;
    public string FileName = string.Empty;
    public int? MaxFileSize;
    public int? MaxRetainedFiles;

    /// <summary>
    /// Creates a new instance of <see cref="AzureAppServicesFileLoggerProvider"/>.
    /// </summary>
    /// <param name="options">The options to use when creating a provider.</param>
    [SuppressMessage("ApiDesign", "RS0022:Constructor make noninheritable base class inheritable", Justification = "Required for backwards compatibility")]
    protected LocalFileBaseLoggerProvider(
        IOptionsMonitor<TLocalFileBaseLoggerOptions> options
        ) : base(options.CurrentValue) {
        this._Index = ++__Count;

        var loggerOptions = options.CurrentValue;
        this.UpdateOptionsInternal(loggerOptions);
        if (this.IsEnabled) {
            this.Start();
        }
        this._OptionsChangeToken = options.OnChange(this.UpdateOptions);
    }

    protected override void UpdateOptionsInternal(BatchingLoggerOptions options) {
        base.UpdateOptionsInternal(options);
        this.UpdateOptionsThis((TLocalFileBaseLoggerOptions)options);
    }

    private void UpdateOptionsThis(TLocalFileBaseLoggerOptions loggerOptions) {
        this.Path = string.IsNullOrEmpty(loggerOptions.LogDirectory) ? System.IO.Path.GetFullPath(".") : System.IO.Path.GetFullPath(loggerOptions.LogDirectory);
        this.FileName = loggerOptions.FileName;
        this.MaxFileSize = loggerOptions.FileSizeLimit;
        this.MaxRetainedFiles = loggerOptions.RetainedFileCountLimit;
    }

    internal protected override async Task WriteMessagesAsync(IEnumerable<LogMessage> messages, CancellationToken cancellationToken) {
        if (this.Path is null) { throw new System.ArgumentException("Path is null"); }

        Directory.CreateDirectory(this.Path);

        foreach (var group in messages.GroupBy(this.GetGrouping)) {
            var fullName = this.GetFullName(group.Key);
            var fileInfo = new FileInfo(fullName);
            if (this.MaxFileSize.HasValue && this.MaxFileSize > 0 && fileInfo.Exists && fileInfo.Length > this.MaxFileSize) {
                return;
            }
            try {
                using (var streamWriter = File.AppendText(fullName)) {
                    foreach (var item in group) {
                        await streamWriter.WriteAsync(item.Message).ConfigureAwait(false);
                    }
#if NET8_0_OR_GREATER
                    await streamWriter.FlushAsync().ConfigureAwait(false);
                    await streamWriter.DisposeAsync().ConfigureAwait(false);
#else
                    await streamWriter.FlushAsync().ConfigureAwait(false);
                    streamWriter.Close();
#endif
                }
            } catch (System.Exception error) {
                System.Console.Error.WriteLine(error.ToString());
            }
        }

        this.RollFiles();
    }

    private string GetFullName((int Year, int Month, int Day) group) {
        if (this.Path is null) { throw new System.ArgumentException("_path is null"); }

        return System.IO.Path.Combine(this.Path, $"{this.FileName}{group.Year:0000}{group.Month:00}{group.Day:00}.txt");
    }

    private (int Year, int Month, int Day) GetGrouping(LogMessage message) {
        return (message.Timestamp.Year, message.Timestamp.Month, message.Timestamp.Day);
    }

    private void RollFiles() {
        if (this.Path is null) { throw new System.ArgumentException("_path is null"); }

        try {
            if (this.MaxRetainedFiles is { } maxRetainedFiles
                && maxRetainedFiles > 0) {
                var files = new DirectoryInfo(this.Path)
                    .GetFiles(this.FileName + "*")
                    .OrderByDescending(fileInfo => fileInfo.Name)
                    .Skip(maxRetainedFiles)
                    .ToList();

                foreach (var item in files) {
                    item.Delete();
                }
            }
        } catch (System.Exception error) {
            System.Console.Error.WriteLine(error.ToString());
        }
    }
}

[ProviderAlias("LocalFile")]
public sealed class LocalFileLoggerProvider : LocalFileBaseLoggerProvider<LocalFileLoggerOptions> {
    public LocalFileLoggerProvider(IOptionsMonitor<LocalFileLoggerOptions> options) : base(options) { }
}

[ProviderAlias("LocalFile1")]
public sealed class LocalFile1LoggerProvider : LocalFileBaseLoggerProvider<LocalFile1LoggerOptions> {
    public LocalFile1LoggerProvider(IOptionsMonitor<LocalFile1LoggerOptions> options) : base(options) { }
}

[ProviderAlias("LocalFile2")]
public sealed class LocalFile2LoggerProvider : LocalFileBaseLoggerProvider<LocalFile2LoggerOptions> {
    public LocalFile2LoggerProvider(IOptionsMonitor<LocalFile2LoggerOptions> options) : base(options) { }
}

[ProviderAlias("LocalFile3")]
public sealed class LocalFile3LoggerProvider : LocalFileBaseLoggerProvider<LocalFile3LoggerOptions> {
    public LocalFile3LoggerProvider(IOptionsMonitor<LocalFile3LoggerOptions> options) : base(options) { }
}