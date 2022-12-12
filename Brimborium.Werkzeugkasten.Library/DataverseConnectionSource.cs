namespace Brimborium.Werkzeugkasten.Library;

public class DataverseConnectionSource {
    public string ConnectionName { get; set; } = "default";
    public string? ConfigurationFile { get; set; }
    public string? UserSecretsId { get; set; }
}

public class DataverseConnectionSourceUtility {

    public static IConfigurationRoot Resolve(ConfigurationBuilder configurationBuilder) {
        var dataverseConnectionSource = new DataverseConnectionSource();
        var confinguration = configurationBuilder.Build();
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
