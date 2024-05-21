namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.New, nameof(WKPSAppHost), ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = false, SupportsTransactions = false)]
[OutputType(typeof(WKPSAppHost))]
public sealed class NewWKPSAppHostCmdlet : PSCmdlet {
    [Parameter(Position = 0)]
    public string? ApplicationName { get; set; }

    [Parameter(Position = 1)]
    public string? ContentRootPath { get; set; }

    [Parameter(Position = 2)]
    public string? AppSettingsJsonPath { get; set; }

    [Parameter(Position = 3)]
    public SwitchParameter ApplyHostConfiguration { get; set; }

    protected override void ProcessRecord() {
        var appHost = WKPSAppHost.Create(this.ApplicationName, this.ContentRootPath);

        if (this.AppSettingsJsonPath is { Length: > 0 } appSettingsJsonPath) {
            appHost.AddConfigurationJsonFile(appSettingsJsonPath, false);
            if (this.ApplyHostConfiguration.ToBool()) {
                appHost.ApplyHostConfiguration();
            }
        } else {
            appSettingsJsonPath = System.IO.Path.Combine(appHost.HostBuilder.Environment.ContentRootPath, "appsettings.json");
            if (System.IO.File.Exists(appSettingsJsonPath)) {
                appHost.AddConfigurationJsonFile(appSettingsJsonPath, false);
                if (this.ApplyHostConfiguration.ToBool()) {
                    appHost.ApplyHostConfiguration();
                }
            }
        }

        this.WriteObject(appHost);
    }
}
