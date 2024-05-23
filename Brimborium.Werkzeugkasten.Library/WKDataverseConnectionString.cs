namespace Brimborium.Werkzeugkasten;

public class WKDataverseConnectionString : Microsoft.PowerPlatform.Dataverse.Client.Model.ConnectionOptions {
    public string? Name { get; set; }

    public string? ConnectionString { get; set; }

    public string? ClientSecretEncrypted { get; set; }

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.ConnectionString), default) is { } connectionString) {
            this.ConnectionString = connectionString;
        }
        if (configuration.GetValue<Microsoft.PowerPlatform.Dataverse.Client.AuthenticationType?>(nameof(WKDataverseConnectionString.AuthenticationType), default) is Microsoft.PowerPlatform.Dataverse.Client.AuthenticationType authenticationType) {
            this.AuthenticationType = authenticationType;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.ServiceUri), default) is { } serviceUri) {
            this.ServiceUri = new Uri(serviceUri, UriKind.Absolute);
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.UserName), default) is { } userName) {
            this.UserName = userName;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.Password), default) is { } password) {
            System.Security.SecureString secureString = new();
            //TODO: secureString
            //this.Password = userName;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.Domain), default) is { } domain) {
            this.Domain = domain;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.HomeRealmUri), default) is { } homeRealmUri) {
            this.HomeRealmUri = new Uri(homeRealmUri, UriKind.Absolute);
        }
        if (configuration.GetValue<bool?>(nameof(WKDataverseConnectionString.RequireNewInstance), default) is { } requireNewInstance) {
            this.RequireNewInstance = requireNewInstance;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.ClientId), default) is { } clientId) {
            this.ClientId = clientId;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.ClientSecretEncrypted), default) is { } clientSecretEncrypted) {
            // TODO: unit test
            this.ClientSecret = WKUtility.Unprotect(clientSecretEncrypted).AsString();
        } else if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.ClientSecret), default) is { } clientSecret) {
            this.ClientSecret = clientSecret;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.RedirectUri), default) is { } redirectUri) {
            this.RedirectUri = new Uri(redirectUri, UriKind.Absolute);
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.TokenCacheStorePath), default) is { } tokenCacheStorePath) {
            this.TokenCacheStorePath = tokenCacheStorePath;
        }
        if (configuration.GetValue<PromptBehavior?>(nameof(WKDataverseConnectionString.LoginPrompt), default) is { } loginPrompt) {
            this.LoginPrompt = loginPrompt;
        }
        if (configuration.GetValue<string?>(nameof(WKDataverseConnectionString.CertificateThumbprint), default) is { } certificateThumbprint) {
            this.CertificateThumbprint = certificateThumbprint;
        }
        if (configuration.GetValue<System.Security.Cryptography.X509Certificates.StoreName?>(nameof(WKDataverseConnectionString.CertificateStoreName), default) is { } certificateStoreName) {
            this.CertificateStoreName = certificateStoreName;
        }
        if (configuration.GetValue<bool?>(nameof(WKDataverseConnectionString.SkipDiscovery), default) is { } skipDiscovery) {
            this.SkipDiscovery = skipDiscovery;
        }
        if (configuration.GetValue<bool?>(nameof(WKDataverseConnectionString.UseCurrentUserForLogin), default) is { } useCurrentUserForLogin) {
            this.UseCurrentUserForLogin = useCurrentUserForLogin;
        }
    }
}