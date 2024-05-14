namespace Brimborium.WhoAmIWerkzeug;

public static class Program {
    public static async Task<int> Main(string[] args) {
        return await BootApp.RunAsync<GetWhoAmIWerkzeug>(args, typeof(Program).Assembly);
    }
}

public class GetWhoAmIWerkzeugArguments : BaseWerkzeugArguments {
}

[Transient]
public class GetWhoAmIWerkzeug : IWerkzeug {
    private readonly IConfigurationRoot _Configuration;

    public GetWhoAmIWerkzeug(IConfigurationRoot configuration) {
        this._Configuration = configuration;
    }
    public async Task<int> ExecuteAsync() {
        var args = new GetWhoAmIWerkzeugArguments();
        this._Configuration.Bind(args);
        return await this.ExecuteReadAsync(args);
    }

    public async Task<int> ExecuteReadAsync(GetWhoAmIWerkzeugArguments args) {
        var connectionString = BaseWerkzeugArgumentsUtility.GetConnectionString(this._Configuration, args);
        if (string.IsNullOrEmpty(connectionString)) { throw new ArgumentException($"ConnectionString:{args.ConnectionName} not found."); }

        try {
            using var serviceClient = new ServiceClient(connectionString);
            var resp = (WhoAmIResponse)await serviceClient.ExecuteAsync(new WhoAmIRequest());
            Console.WriteLine("User ID is {0}.", resp.UserId);
        } catch (Exception ex) {
            System.Console.Error.WriteLine(ex.ToString());
            return -1;
        }
        return 0;
    }
}
