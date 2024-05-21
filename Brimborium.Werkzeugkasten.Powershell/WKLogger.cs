namespace Brimborium.Werkzeugkasten;

/// <summary>
/// Powershell compatible logger.
/// </summary>
/// <param name="logger"></param>
public sealed class WKLogger(ILogger logger) : ILogger {
    private readonly ILogger _Logger = logger;

    #region ILogger
    void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        => this._Logger.Log(logLevel, eventId, state, exception, formatter);

    bool ILogger.IsEnabled(LogLevel logLevel)
        => this._Logger.IsEnabled(logLevel);

    IDisposable? ILogger.BeginScope<TState>(TState state)
        //where TState : notnull 
        => this._Logger.BeginScope(state);
    #endregion ILogger
    // LogTrace

    public void LogTrace(string message, params object?[] args)
        => this.LogMessage(LogLevel.Trace, (EventId)0, message, args);

    public void LogTrace(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Trace, (EventId)0, exception, message, args);

    public void LogTrace(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Trace, (EventId)0, errorRecord, message, args);

    public void LogTrace(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Trace, eventId, message, args);

    public void LogTrace(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Trace, eventId, exception, message, args);

    public void LogTrace(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Trace, eventId, errorRecord, message, args);


    // LogDebug

    public void LogDebug(string message, params object?[] args)
        => this.LogMessage(LogLevel.Debug, (EventId)0, message, args);

    public void LogDebug(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Debug, (EventId)0, exception, message, args);

    public void LogDebug(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Debug, (EventId)0, errorRecord, message, args);

    public void LogDebug(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Debug, eventId, message, args);

    public void LogDebug(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Debug, eventId, exception, message, args);

    public void LogDebug(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Debug, eventId, errorRecord, message, args);


    // LogInformation

    public void LogInformation(string message, params object?[] args)
        => this.LogMessage(LogLevel.Information, (EventId)0, message, args);

    public void LogInformation(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Information, (EventId)0, exception, message, args);

    public void LogInformation(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Information, (EventId)0, errorRecord, message, args);

    public void LogInformation(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Information, eventId, message, args);

    public void LogInformation(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Information, eventId, exception, message, args);

    public void LogInformation(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Information, eventId, errorRecord, message, args);


    // LogWarning

    public void LogWarning(string message, params object?[] args)
        => this.LogMessage(LogLevel.Warning, (EventId)0, message, args);

    public void LogWarning(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Warning, (EventId)0, exception, message, args);

    public void LogWarning(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Warning, (EventId)0, errorRecord, message, args);

    public void LogWarning(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Warning, eventId, message, args);

    public void LogWarning(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Warning, eventId, exception, message, args);

    public void LogWarning(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Warning, eventId, errorRecord, message, args);


    // LogError

    public void LogError(string message, params object?[] args)
        => this.LogMessage(LogLevel.Error, (EventId)0, message, args);

    public void LogError(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Error, (EventId)0, exception, message, args);

    public void LogError(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Error, (EventId)0, errorRecord, message, args);

    public void LogError(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Error, eventId, message, args);

    public void LogError(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Error, eventId, exception, message, args);

    public void LogError(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Error, eventId, errorRecord, message, args);


    // LogCritical

    public void LogCritical(string message, params object?[] args)
        => this.LogMessage(LogLevel.Critical, (EventId)0, message, args);

    public void LogCritical(Exception exception, string message, params object?[] args)
        => this.LogException(LogLevel.Critical, (EventId)0, exception, message, args);

    public void LogCritical(ErrorRecord errorRecord, string message, params object?[] args)
        => this.LogErrorRecord(LogLevel.Critical, (EventId)0, errorRecord, message, args);

    public void LogCritical(EventId eventId, string message, params object?[] args)
        => this.LogMessage(LogLevel.Critical, eventId, message, args);

    public void LogCritical(EventId eventId, Exception? exception, string message, params object?[] args)
        => this.LogException(LogLevel.Critical, eventId, exception, message, args);

    public void LogCritical(EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args)
       => this.LogErrorRecord(LogLevel.Critical, eventId, errorRecord, message, args);

    // Log

    public void LogMessage(LogLevel logLevel, EventId eventId, string message, params object?[] args) {
        if (this._Logger.IsEnabled(logLevel)) {
            this._Logger.Log(logLevel, eventId, null, message, args);
        }
    }

    public void LogException(LogLevel logLevel, EventId eventId, Exception? exception, string? message, params object?[] args) {
        if (this._Logger.IsEnabled(logLevel)) {
            this._Logger.Log(logLevel, eventId, exception, message, args);
        }
    }

    public void LogErrorRecord(LogLevel logLevel, EventId eventId, ErrorRecord? errorRecord, string? message, params object?[] args) {
        if (this._Logger.IsEnabled(logLevel)) {
            if (errorRecord is not null) {
                this._Logger.LogCritical(eventId, null, "{0} {1}", errorRecord.ToString(), errorRecord.InvocationInfo);
            }
            this._Logger.Log(logLevel, eventId, errorRecord?.Exception, message, args);
        }
    }
}
