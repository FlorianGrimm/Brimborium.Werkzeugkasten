namespace Brimborium.Werkzeugkasten.Library;

public class DataverseConnectionSource {
    public string ConnectionName { get; set; } = "default";
    public string? ConfigurationFile { get; set; }
    public string? UserSecretsId { get; set; }
}

[Transient]
public class ReadDataverseConnectionSource{
    private readonly DataverseConnectionSource _Options;
    private readonly IConfigurationRoot _Configuration;

    public ReadDataverseConnectionSource(
        IOptions<DataverseConnectionSource> dataverseConnectionSource,
        IConfigurationRoot configuration
    ){
        this._Options = dataverseConnectionSource.Value;
        this._Configuration = configuration;
    }

    public string? GetConnectionString() {
        return this._Configuration.GetConnectionString(this._Options.ConnectionName);
    }
}

public class DataverseConnectionSourceUtility {
    /// <summary>
    /// Configure the configuration builder with the DataverseConnectionSource.
    /// </summary>
    /// <param name="configurationBuilder">the builder to configure - side effect by intension</param>
    /// <returns>a new configuration</returns>
    public static IConfigurationRoot Resolve(ConfigurationBuilder configurationBuilder) {
        var confinguration = configurationBuilder.Build();

        var dataverseConnectionSource = new DataverseConnectionSource();
        confinguration.Bind(dataverseConnectionSource);

        if (!string.IsNullOrEmpty(dataverseConnectionSource.ConfigurationFile)) {
            configurationBuilder.AddJsonFile(dataverseConnectionSource.ConfigurationFile, optional:true);
        }
        if (!string.IsNullOrEmpty(dataverseConnectionSource.UserSecretsId)) {
            configurationBuilder.AddUserSecrets(dataverseConnectionSource.UserSecretsId);
        }
        return configurationBuilder.Build();
	}
}
