namespace Brimborium.Werkzeugkasten.FileLogging;

public class LocalFileBaseLoggerConfigureOptions<TLocalFileLoggerOptions> : BatchLoggerConfigureOptions<TLocalFileLoggerOptions>
    where TLocalFileLoggerOptions : LocalFileBaseLoggerOptions {
    protected LocalFileBaseLoggerConfigureOptions(IConfiguration configuration) : base(configuration) { }

    protected string? GetCfgValue(string key) {
        return this._Configuration[key];
    }

    public override void Configure(TLocalFileLoggerOptions options) {
        base.Configure(options);

        options.FileSizeLimit = TextToInt(
            this.GetCfgValue("SizeLimit"),
            null,
            (value) => ((value.HasValue) ? value.Value * 1024 * 1024 : null)
            );
        options.RetainedFileCountLimit = TextToInt(
            this.GetCfgValue("RetainedFileCountLimit"),
            31,
            (value) => (value ?? 10)
            );
        options.FlushPeriod = TextToTimeSpan(this.GetCfgValue("FlushPeriod")).GetValueOrDefault(TimeSpan.FromSeconds(1));
        options.IncludeScopes = TextToBoolean(this.GetCfgValue("IncludeScopes"));
        options.TimestampFormat = this.GetCfgValue("TimestampFormat");
        options.UseUtcTimestamp = TextToBoolean(this.GetCfgValue("UseUtcTimestamp"));
        options.IncludeEventId = TextToBoolean(this.GetCfgValue("IncludeEventId"));
        options.UseJSONFormat = TextToBoolean(this.GetCfgValue("UseJSONFormat"));

        {
            var logDirectory = this.GetCfgValue("LogDirectory");
            if (!string.IsNullOrEmpty(logDirectory)) {
                options.LogDirectory = logDirectory;
            }
        }
        if (string.IsNullOrEmpty(options.LogDirectory)) {
            this._HomeFolder ??= (Environment.GetEnvironmentVariable("HOME") ?? ".");
            // options.LogDirectory = Path.Combine(this._HomeFolder ?? ".", "LogFiles", "Application");
            options.LogDirectory = Path.Combine(this._HomeFolder ?? ".", "LogFiles");
        }
        if (!System.IO.Path.IsPathRooted(options.LogDirectory)) {
            options.LogDirectory = System.IO.Path.GetFullPath(options.LogDirectory);
        }
    }

    private string? _HomeFolder;
}

public class LocalFileLoggerConfigureOptions
    : LocalFileBaseLoggerConfigureOptions<LocalFileLoggerOptions>, IConfigureOptions<LocalFileLoggerOptions> {
    public LocalFileLoggerConfigureOptions(IConfiguration configuration) : base(configuration) { }
}

public class LocalFile1LoggerConfigureOptions
    : LocalFileBaseLoggerConfigureOptions<LocalFile1LoggerOptions>, IConfigureOptions<LocalFile1LoggerOptions> {
    public LocalFile1LoggerConfigureOptions(IConfiguration configuration) : base(configuration) { }
}

public class LocalFile2LoggerConfigureOptions
    : LocalFileBaseLoggerConfigureOptions<LocalFile2LoggerOptions>, IConfigureOptions<LocalFile2LoggerOptions> {
    public LocalFile2LoggerConfigureOptions(IConfiguration configuration) : base(configuration) { }
}

public class LocalFile3LoggerConfigureOptions
    : LocalFileBaseLoggerConfigureOptions<LocalFile3LoggerOptions>, IConfigureOptions<LocalFile3LoggerOptions> {
    public LocalFile3LoggerConfigureOptions(IConfiguration configuration) : base(configuration) { }
}
