namespace Brimborium.Werkzeugkasten;

// ConvertTo-SolvinDataverseDatatable
[Cmdlet(VerbsData.ConvertTo, "WKDatatable")]
[OutputType(typeof(System.Int64))]
public sealed class ConvertToWKDataTableCmdlet : PSCmdlet {
    private const string Versionnumber = "versionnumber";

    [Parameter(Mandatory = true, Position = 0)]
    public Microsoft.Xrm.Sdk.EntityCollection? InputCollection { get; set; }

    [Parameter(Mandatory = true, Position = 1)]
    public System.Data.DataTable? OutputDataTable { get; set; }

    [Parameter(Mandatory = true, Position = 2)]
    public WKMetaEntity? MetaEntity { get; set; }

    [Parameter(Mandatory = false, Position = 3)]
    public WKMappingEntity? MappingEntity { get; set; }

    protected override void BeginProcessing() {
        base.BeginProcessing();
        if (!(this.InputCollection is { } inputCollection)) { throw new ArgumentNullException(nameof(this.InputCollection)); }
        if (!(this.OutputDataTable is { } outputDataTable)) { throw new ArgumentNullException(nameof(this.OutputDataTable)); }
        if (!(this.MetaEntity is { } metaEntity)) { throw new ArgumentNullException(nameof(this.MetaEntity)); }

        WKMappingEntity mappingEntity = this.MappingEntity ?? this.MetaEntity.GetMappingEntity();
        var mappingEntityAttributeToColumn = mappingEntity.GetMappingEntityAttributeToColumn(metaEntity, outputDataTable);

        var result = WKUtility.CopyToDataTable(this.MetaEntity, inputCollection, outputDataTable, mappingEntityAttributeToColumn);

        this.WriteObject(result);
    }
}
