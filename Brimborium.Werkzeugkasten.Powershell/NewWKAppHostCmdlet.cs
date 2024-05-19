namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.New, "WKAppHost")]
[OutputType(typeof(WKAppHost))]
public sealed class NewWKAppHostCmdlet : PSCmdlet {
    protected override void ProcessRecord() {
        var appHost = new WKAppHost();
        this.WriteObject(appHost);
    }
}

