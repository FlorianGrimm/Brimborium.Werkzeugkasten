namespace Brimborium.Werkzeugkasten.App;

public enum ConfigurationFileWerkzeugActions {
    Add = 1, Remove = 2, Show = 3
}
public class ConfigurationWerkzeugArguments : BaseWerkzeugArguments {
    public ConfigurationFileWerkzeugActions? Action { get; set; }
}

public class ConfigurationFileWerkzeug : IWerkzeug {
    private readonly ConnectionOptions _ConnectionOptions;

    public ConfigurationFileWerkzeug(IOptions<ConnectionOptions> connectionOptions) {
        this._ConnectionOptions = connectionOptions.Value;
    }

    public async Task<int> ExecuteAsync(WerkzeugContext context) {
        var args = new ConfigurationWerkzeugArguments();
        context.Confinguration.Bind(args);
        if (!args.Action.HasValue) {
            System.Console.Error.WriteLine("--action required. Add | Remove | Show");
            return -1;
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Add) {
            return await this.ExecuteAddAsync(args, context);
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Remove) {
            return await this.ExecuteRemoveAsync(args, context);
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Show) {
            return await this.ExecuteShowAsync(args, context);
        } else { 
            System.Console.Error.WriteLine($"--action '{args.Action}' unknown. Add | Remove | Show");
            return -1;
        }
    }

    public async Task<int> ExecuteAddAsync(ConfigurationWerkzeugArguments args, WerkzeugContext context) {
        await Task.Delay(1);
        return -1;
    }

    public async Task<int> ExecuteRemoveAsync(ConfigurationWerkzeugArguments args, WerkzeugContext context) {
        await Task.Delay(1);
        return -1;
    }

    public async Task<int> ExecuteShowAsync(ConfigurationWerkzeugArguments args, WerkzeugContext context) {
        await Task.Delay(1);
        return -1;
    }
}
