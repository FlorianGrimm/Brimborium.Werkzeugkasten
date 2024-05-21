using Microsoft.Extensions.Hosting;

namespace Brimborium.Werkzeugkasten;

public sealed class WKPSAppHost : WKAppHost {
    public static WKPSAppHost Create(
        string? applicationName = default,
        string? contentRootPath = default) {
        if (string.IsNullOrWhiteSpace(applicationName)) { applicationName = "Powershell"; }
        if (string.IsNullOrWhiteSpace(contentRootPath)) { contentRootPath = System.IO.Path.GetFullPath("."); }

        var settings = new Microsoft.Extensions.Hosting.HostApplicationBuilderSettings();
        settings.ApplicationName = applicationName;
        settings.ContentRootPath = contentRootPath;
        var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
        var result = new WKPSAppHost(hostBuilder);
        result._AppHostOption.ApplicationName = applicationName;
        result._AppHostOption.ContentRootPath = contentRootPath;
        return result;
    }

    public WKPSAppHost(HostApplicationBuilder? hostBuilder) : base(hostBuilder) {
    }

    private readonly Dictionary<string, WKLogger> _LoggerByName = new(StringComparer.OrdinalIgnoreCase);
    public WKLogger GetLogger(string? name = default) {
        var key = name ?? this._HostBuilder.Environment.ApplicationName ?? "Powershell";
        if (!this._LoggerByName.TryGetValue(key, out var result)) {
            var loggerFactory = this.GetHost().Services.GetRequiredService<Microsoft.Extensions.Logging.ILoggerFactory>();
            result = new WKLogger(loggerFactory.CreateLogger(key));
            this._LoggerByName.Add(key, result);
        }
        return result;
    }
}