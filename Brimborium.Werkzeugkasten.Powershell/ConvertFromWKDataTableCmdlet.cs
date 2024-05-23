namespace Brimborium.Werkzeugkasten;


// ConvertFrom-WKDatatable
[Cmdlet(VerbsData.ConvertFrom, "WKDatatable")]
[OutputType(typeof(Microsoft.Xrm.Sdk.EntityCollection))]
public sealed class ConvertFromWKDataTableCmdlet : PSCmdlet {
    private const string Versionnumber = "versionnumber";

    [Parameter(Mandatory = true, Position = 0)]
    public System.Data.DataTable? InputDataTable { get; set; }

    [Parameter(Mandatory = true, Position = 1)]
    public Microsoft.Xrm.Sdk.EntityCollection? OutputCollection { get; set; }

    [Parameter(Mandatory = true, Position = 2)]
    public WKMetaEntity? MetaEntity { get; set; }

    [Parameter(Mandatory = false, Position = 3)]
    public WKMappingEntity? MappingEntity { get; set; }

    protected override void BeginProcessing() {
        base.BeginProcessing();
        if (!(this.InputDataTable is { } inputDataTable)) { throw new ArgumentNullException(nameof(this.InputDataTable)); }
        var outputCollection = this.OutputCollection ?? new EntityCollection();
        
        if (!(this.MetaEntity is { } metaEntity)) { throw new ArgumentNullException(nameof(this.MetaEntity)); }
        WKMappingEntity mappingEntity = this.MappingEntity ?? metaEntity.GetMappingEntity();
        var mappingEntityColumnToAttribute = mappingEntity.GetMappingEntityColumnToAttribute(inputDataTable, metaEntity);

        WKUtility.CopyFromDataTable(inputDataTable, this.MetaEntity, outputCollection, mappingEntityColumnToAttribute);
        this.WriteObject(outputCollection);
    }
}
