namespace Brimborium.Werkzeugkasten.FileLogging;

[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public readonly struct LogMessage {
    public LogMessage(DateTimeOffset timestamp, string message) {
        this.Timestamp = timestamp;
        this.Message = message;
    }

    public DateTimeOffset Timestamp { get; }
    public string Message { get; }
}
/*
public record struct LogMessage(
    string LogName, 
    LogLevel LogLevel, 
    EventId EventId, 
    string Message, 
    Exception? Exception);
*/