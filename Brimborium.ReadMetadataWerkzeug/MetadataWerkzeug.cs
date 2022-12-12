using Microsoft.Crm.Sdk.Messages;

namespace Brimborium.ReadMetadataWerkzeug;

public class MetadataWerkzeugArguments : BaseWerkzeugArguments {
    //public ConfigurationFileWerkzeugActions? Action { get; set; }
}

public class MetadataWerkzeug : IWerkzeug {
    public MetadataWerkzeug() {
    }

    public async Task<int> ExecuteAsync(WerkzeugContext context) {
        var args = new MetadataWerkzeugArguments();
        
        return await this.ExecuteReadAsync(args, context);
    }

    private async Task<int> ExecuteReadAsync(MetadataWerkzeugArguments args, WerkzeugContext context) {
        var connectionString = BaseWerkzeugArgumentsUtility.GetConnectionString(context.Confinguration, args);
        if (string.IsNullOrEmpty(connectionString)) { throw new ArgumentException($"ConnectionString:{args.ConnectionName} not found."); }
        await Task.Delay(1);

        using var serviceClient = new ServiceClient(connectionString);
        WhoAmIResponse resp = (WhoAmIResponse)serviceClient.Execute(new WhoAmIRequest());
        Console.WriteLine("User ID is {0}.", resp.UserId);
        return 0;
    }
}
