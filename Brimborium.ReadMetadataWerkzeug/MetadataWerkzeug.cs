using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;

using Newtonsoft.Json.Linq;

using System.Collections.Immutable;

namespace Brimborium.ReadMetadataWerkzeug;

public class MetadataWerkzeugArguments : BaseWerkzeugArguments {
    //public ConfigurationFileWerkzeugActions? Action { get; set; }
    public string? Input { get; set; }
    public string? Output { get; set; }
}
public class MetadataWerkzeugInput {
    // TODO also add filter like solution, ...
    public List<EnableEntityMetadata> EnableEntityMetadata = new List<EnableEntityMetadata>();
}
public class EnableEntityMetadata {
    public string? LogicalName { get; set; }
    public bool IsEnabled { get; set; } = false;
}

public class DataverseState {
    public List<Microsoft.Xrm.Sdk.Metadata.EntityMetadata> EntityMetadata = new List<Microsoft.Xrm.Sdk.Metadata.EntityMetadata>();
}

[Transient()]
public class MetadataWerkzeug : IWerkzeug {
    private readonly IConfigurationRoot _Configuration;

    public MetadataWerkzeug(
        IConfigurationRoot configuration
        ) {
        this._Configuration = configuration;
    }

    public async Task<int> ExecuteAsync() {
        var args = new MetadataWerkzeugArguments();
        this._Configuration.Bind(args);
        return await this.ExecuteReadAsync(args);
    }

    public async Task<int> ExecuteReadAsync(MetadataWerkzeugArguments args) {
        var connectionString = BaseWerkzeugArgumentsUtility.GetConnectionString(this._Configuration, args);
        if (string.IsNullOrEmpty(connectionString)) { throw new ArgumentException($"ConnectionString:{args.ConnectionName} not found."); }

        //var input = new MetadataWerkzeugInput();
        MetadataWerkzeugInput input = this.ReadInput(args.Input);

        var hsEnabledLogicalName = new HashSet<string>(
                input.EnableEntityMetadata.Where(e => e.IsEnabled && e.LogicalName is not null).Select(e => e.LogicalName!)
            );

        var hsAllLogicalName = new HashSet<string>(
                input.EnableEntityMetadata.Where(e => e.LogicalName is not null).Select(e => e.LogicalName!)
            );

        using var serviceClient = new ServiceClient(connectionString);
        var resp = (Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesResponse)await serviceClient.ExecuteAsync(
            new Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesRequest()
            );

        Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]? arrEntityMetadata = resp.EntityMetadata;
        if (arrEntityMetadata is null) { throw new Exception("arrEntityMetadata is null"); }
        
        /*
        */
        foreach (var r in arrEntityMetadata) {
            System.Console.Out.WriteLine(r.EntitySetName);
        }

        var output = new DataverseState() {
            EntityMetadata = arrEntityMetadata.Where(
                e => hsEnabledLogicalName.Contains(e.LogicalName)
                ).ToList()
        };

        var toAdd = arrEntityMetadata
                .Where(e => e.LogicalName is not null
                            && !hsAllLogicalName.Contains(e.LogicalName))
                .Select(e => {
                    return new EnableEntityMetadata() {
                        LogicalName = e.LogicalName,
                        IsEnabled = false
                    };
                })
                .ToList();

        if (toAdd.Any()) {
            input.EnableEntityMetadata.AddRange(toAdd);
            this.WriteInput(args.Input, input);
        }
        this.WriteOutput(args.Output, output);

        //RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest {
        //    EntityFilters = EntityFilters.All
        //};
        //var retrieveEntityResponse = (RetrieveEntityResponse)await serviceClient.ExecuteAsync(retrieveEntityRequest);
        //retrieveEntityResponse.EntityMetadata
        //EntityMetadata AccountEntity = retrieveAccountEntityResponse.EntityMetadata;


        //var service = serviceClient.OrganizationWebProxyClient is not null
        //    ? serviceClient.OrganizationWebProxyClient
        //    : serviceClient.OrganizationServiceProxy;

        //IOrganizationService service;
        //service = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
        //var resp = (WhoAmIResponse) await serviceClient.ExecuteAsync(new EntityMetaDataInfo());

        /*
         HTTP

        Copy
        GET [Organization URI]/api/data/v9.0/EntityDefinitions?$filter=LogicalName%20eq%20'account'&$select=MetadataId HTTP/1.1  
        OData-MaxVersion: 4.0  
        OData-Version: 4.0  
        Accept: application/json  
        Content-Type: application/json; charset=utf-8  
         */
        //Console.WriteLine("User ID is {0}.", resp.UserId);
        return 0;
    }


    private MetadataWerkzeugInput ReadInput(string? inputFileName) {
        if (string.IsNullOrEmpty(inputFileName)) {
            return new MetadataWerkzeugInput();
        } else {
            var content = System.IO.File.ReadAllText(inputFileName);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MetadataWerkzeugInput>(content)
                ?? new MetadataWerkzeugInput();
        }
    }


    private void WriteInput(string? inputFilename, MetadataWerkzeugInput value) {
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(
            value,
            Newtonsoft.Json.Formatting.Indented);
        if (string.IsNullOrEmpty(inputFilename)) {
            System.Console.Out.WriteLine(content);
        } else {
            System.IO.File.WriteAllText(inputFilename, content);
        }
    }

    private void WriteOutput(string outputFilename, DataverseState value) {
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(
            value,
            Newtonsoft.Json.Formatting.Indented);
        if (string.IsNullOrEmpty(outputFilename)) {
            System.Console.Out.WriteLine(content);
        } else {
            System.IO.File.WriteAllText(outputFilename, content);
        }
    }
}
