namespace Brimborium.Werkzeugkasten;

public class WKAppHostOption {
    public WKAppHostOption() { }

    public string? ApplicationName { get; set; }

    public string? ContentRootPath { get; set; }

    public string[]? ConfigurationJsonFile { get; set; }

    public string[]? ConfigurationUserSecret { get; set; }

    public string[]? EnableLogger { get; set; }

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<string?>(nameof(WKAppHostOption.ApplicationName), null) is { Length: > 0 } applicationName) {
            this.ApplicationName = applicationName;
        }
        if (configuration.GetValue<string?>(nameof(WKAppHostOption.ContentRootPath), null) is { Length: > 0 } contentRootPath) {
            this.ContentRootPath = contentRootPath;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.ConfigurationJsonFile), null) is { Length: > 0 } configurationJsonFile) {
            this.ConfigurationJsonFile = configurationJsonFile;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.ConfigurationUserSecret), null) is { Length: > 0 } configurationUserSecret) {
            this.ConfigurationUserSecret = configurationUserSecret;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.EnableLogger), null) is { Length: > 0 } enableLogger) {
            this.EnableLogger = enableLogger;
        }
    }
}
