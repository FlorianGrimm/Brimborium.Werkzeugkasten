namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.Get, nameof(WKLogger), ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = false, SupportsTransactions = false)]
[OutputType(typeof(WKLogger))]
public sealed class GetWKLoggerCmdlet : PSCmdlet {
    [Parameter(Position = 0, Mandatory = true)]
    public WKPSAppHost? WKPSAppHost { get; set; }

    [Parameter(Position = 1, Mandatory = false)]
    public string? Name { get; set; }

    protected override void BeginProcessing() {
        if (!(this.WKPSAppHost is { } wkPSAppHost)) { throw new ArgumentNullException(nameof(this.WKPSAppHost)); }

        var result = wkPSAppHost.GetLogger(this.Name);
        this.WriteObject(result);
    }
}
