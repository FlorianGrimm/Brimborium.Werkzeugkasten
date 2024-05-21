namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.New, "WKAppHost", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = false, SupportsTransactions = false)]
[OutputType(typeof(WKAppHost))]
public sealed class NewWKAppHostCmdlet : PSCmdlet {
    [Parameter(Position = 0)]
    public string? ApplicationName { get; set; }

    [Parameter(Position = 1)]
    public string? ContentRootPath { get; set; }

    [Parameter(Position = 2)]
    public string? AppSettingsJsonPath { get; set; }

    protected override void ProcessRecord() {
        var appHost = WKAppHost.Create(this.ApplicationName, this.ContentRootPath);


        if (this.AppSettingsJsonPath is { Length: > 0 } appSettingsJsonPath) {
            appHost.AddConfigurationJsonFile(appSettingsJsonPath, false);
            appHost.ApplyHostConfiguration();
        }

        this.WriteObject(appHost);
    }
}

