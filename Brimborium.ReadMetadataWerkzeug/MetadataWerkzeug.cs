using Microsoft.Crm.Sdk.Messages;

namespace Brimborium.ReadMetadataWerkzeug;

public class MetadataWerkzeugArguments : BaseWerkzeugArguments {
    //public ConfigurationFileWerkzeugActions? Action { get; set; }
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
        await Task.Delay(1);

        using var serviceClient = new ServiceClient(connectionString);
        var resp = (WhoAmIResponse) await serviceClient.ExecuteAsync(new WhoAmIRequest());
        Console.WriteLine("User ID is {0}.", resp.UserId);
        return 0;
    }
}
