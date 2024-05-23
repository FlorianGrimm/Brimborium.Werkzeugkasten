namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsData.Export, "WKSolution",
    ConfirmImpact = ConfirmImpact.None,
    DefaultParameterSetName = "Content",
    RemotingCapability = RemotingCapability.None,
    SupportsPaging = false,
    SupportsShouldProcess = false,
    SupportsTransactions = false)]
[OutputType(typeof(byte[]), ParameterSetName = [ParameterSetNameContent])]
[OutputType(typeof(byte[]), ParameterSetName = [ParameterSetNameFolder])]
public sealed class ExportWKSolutionCmdlet : PSCmdlet {
    private const string ParameterSetNameContent = "Content";
    private const string ParameterSetNameFolder = nameof(ExportWKSolutionCmdlet.Folder);
    [Parameter(Mandatory = true, Position = 0)]
    public WKDataverseConnection? Connection { get; set; }

    [Parameter(Mandatory = true, Position = 1)]
    public string? SolutionName { get; set; }

    [Parameter(Mandatory = false, Position = 2)]
    public bool Managed { get; set; } = false;

    [Parameter(Mandatory = false, Position = 3, ParameterSetName = ParameterSetNameFolder)]
    public string? Folder { get; set; }

    [Parameter(Mandatory = false, Position = 4, ParameterSetName = ParameterSetNameFolder)]
    public string? FileName { get; set; }

    protected override void BeginProcessing() {
        base.BeginProcessing();
        if (this.Connection is null) { throw new ArgumentNullException(nameof(this.Connection)); }
        if (string.IsNullOrEmpty(this.SolutionName)) { throw new ArgumentNullException(nameof(this.SolutionName)); }

        ExportSolutionRequest request = new ExportSolutionRequest() {
            SolutionName = this.SolutionName,
            Managed = this.Managed
        };

        var response = (ExportSolutionResponse)this.Connection.Execute(request);
        if (response.ExportSolutionFile is byte[] bytes && bytes.Length > 0) {

            if (string.Equals(this.ParameterSetName, ParameterSetNameFolder)) {
                var folder = this.Folder.GetValueOrDefault(".");
                var now = System.DateTime.Now;
                string fileName = this.FileName.GetValueOrDefault("{SolutionName}-{Now}.zip")
                    .Replace("{SolutionName}", this.SolutionName)
                    .Replace("{Now}", now.ToString("yyyy-MM-dd-HH-mm-ss"))
                    .Replace("{Today}", now.ToString("yyyy-MM-dd"))
                    ;
                var exportPath = Path.Combine(folder, fileName);
                System.IO.File.WriteAllBytes(exportPath, bytes);
                this.WriteObject(exportPath);
            }
            if (string.Equals(this.ParameterSetName, ParameterSetNameContent, StringComparison.Ordinal)) {
                this.WriteObject(bytes);
            }
        } else {
            this.WriteObject(null);
        }
    }
}
