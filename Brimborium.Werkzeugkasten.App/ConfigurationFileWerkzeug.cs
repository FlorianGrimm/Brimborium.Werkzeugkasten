namespace Brimborium.Werkzeugkasten.App;

public enum ConfigurationFileWerkzeugActions {
    Add = 1, Remove = 2, Show = 3
}
public class ConfigurationWerkzeugArguments : BaseWerkzeugArguments {
    public ConfigurationFileWerkzeugActions? Action { get; set; }
}

public class ConfigurationFileWerkzeug : IWerkzeug {
    private readonly ConnectionOptions _ConnectionOptions;
    private readonly IConfigurationRoot _Configuration;

    public ConfigurationFileWerkzeug(
        IConfigurationRoot configuration,
        IOptions<ConnectionOptions> connectionOptions
        ) {
        this._ConnectionOptions = connectionOptions.Value;
        this._Configuration = configuration;
    }

    public async Task<int> ExecuteAsync() {
        var args = new ConfigurationWerkzeugArguments();
        this._Configuration.Bind(args);
        if (!args.Action.HasValue) {
            System.Console.Error.WriteLine("--action required. Add | Remove | Show");
            return -1;
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Add) {
            return await this.ExecuteAddAsync(args);
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Remove) {
            return await this.ExecuteRemoveAsync(args);
        } else if (args.Action.Value == ConfigurationFileWerkzeugActions.Show) {
            return await this.ExecuteShowAsync(args);
        } else { 
            System.Console.Error.WriteLine($"--action '{args.Action}' unknown. Add | Remove | Show");
            return -1;
        }
    }

    public async Task<int> ExecuteAddAsync(ConfigurationWerkzeugArguments args) {
        await Task.Delay(1);
        return -1;
    }

    public async Task<int> ExecuteRemoveAsync(ConfigurationWerkzeugArguments args) {
        await Task.Delay(1);
        return -1;
    }

    public async Task<int> ExecuteShowAsync(ConfigurationWerkzeugArguments args) {
        await Task.Delay(1);
        return -1;
    }
}
