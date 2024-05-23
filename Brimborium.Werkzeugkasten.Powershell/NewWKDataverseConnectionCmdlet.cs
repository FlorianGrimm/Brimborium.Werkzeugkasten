namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.New, nameof(WKDataverseConnection),
    ConfirmImpact = ConfirmImpact.None,
    DefaultParameterSetName = nameof(NewWKDataverseConnectionCmdlet.DataverseConnectionString),
    SupportsShouldProcess = false,
    SupportsTransactions = false)]
[OutputType(typeof(WKDataverseConnection))]
public sealed class NewWKDataverseConnectionCmdlet : PSCmdlet {
    [Parameter(Position = 0, Mandatory = true)]
    public WKPSAppHost? WKPSAppHost { get; set; }

    [Parameter(Position = 1, Mandatory = true, ParameterSetName = nameof(NewWKDataverseConnectionCmdlet.Name))]
    public string? Name { get; set; }

    [Parameter(Position = 1, Mandatory = true, ParameterSetName = nameof(NewWKDataverseConnectionCmdlet.DataverseConnectionString))]
    public WKDataverseConnectionString? DataverseConnectionString { get; set; }

    [Parameter(Position = 2, Mandatory = false)]
    public ILogger? Logger { get; set; }

    protected override void BeginProcessing() {
        if (!(this.WKPSAppHost is { } wkPSAppHost)) { throw new ArgumentNullException(nameof(this.WKPSAppHost)); }

        if (string.Equals(this.ParameterSetName, nameof(NewWKDataverseConnectionCmdlet.DataverseConnectionString), StringComparison.Ordinal)) {
            if (this.DataverseConnectionString is null) { throw new ArgumentNullException(nameof(NewWKDataverseConnectionCmdlet.DataverseConnectionString)); }

            var result = wkPSAppHost.GetWKDataverseConnectionFromConnectionString(this.DataverseConnectionString, this.Logger);
            if (result is not null) {
                this.WriteObject(result);
            }
            return;
        }

        if (string.Equals(this.ParameterSetName, nameof(NewWKDataverseConnectionCmdlet.Name), StringComparison.Ordinal)) {
            if (!(this.Name is { Length: > 0 } name)) { throw new ArgumentNullException(nameof(NewWKDataverseConnectionCmdlet.Name)); }
            var result = wkPSAppHost.GetWKDataverseConnectionFromConfiguration(name, this.Logger);
            if (result is not null) {
                this.WriteObject(result);
            }
            return;
        }

        throw new ArgumentException($"Unexpected ParameterSetName {this.ParameterSetName}");
    }
}
