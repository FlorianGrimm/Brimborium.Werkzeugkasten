
namespace Brimborium.Werkzeugkasten;

public class WKDataverseConnectionString : Microsoft.PowerPlatform.Dataverse.Client.Model.ConnectionOptions {
    public string? Name { get; set; }

    public string? ConnectionString { get; set; }

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
            System.Security.SecureString secureString =new();
            //TODO: secureString
            //this.Password = userName;
        }
#if false
    public string UserName { get; set; }

    //
    // Summary:
    //     User Password to use - Used with Interactive Login scenarios
    public SecureString Password { get; set; }

    //
    // Summary:
    //     User Domain to use - Use with Interactive Login for On Premises
    public string Domain { get; set; }

    //
    // Summary:
    //     Home Realm to use when working with AD Federation.
    public Uri HomeRealmUri { get; set; }

    //
    // Summary:
    //     Require a unique instance of the Dataverse ServiceClient per Login.
    public bool RequireNewInstance { get; set; } = true;


    //
    // Summary:
    //     Client \ Application ID to be used when logging into Dataverse.
    public string ClientId { get; set; } = DataverseConnectionStringProcessor.sampleClientId;


    //
    // Summary:
    //     Client Secret Id to use to login to Dataverse
    public string ClientSecret { get; set; }

    //
    // Summary:
    //     Redirect Uri to use when connecting to dataverse. Required for OAuth Authentication.
    public Uri RedirectUri { get; set; } = new Uri(DataverseConnectionStringProcessor.sampleRedirectUrl);


    //
    // Summary:
    //     Path and FileName for MSAL Token Cache. Used only for OAuth - User Interactive
    //     flows.
    public string TokenCacheStorePath { get; set; }

    //
    // Summary:
    //     Type of Login prompt to use.
    public PromptBehavior? LoginPrompt { get; set; }

    //
    // Summary:
    //     Certificate ThumbPrint to use to lookup machine certificate to use for authentication.
    public string CertificateThumbprint { get; set; }

    //
    // Summary:
    //     Certificate store name to look up thumbprint. System.Security.Cryptography.X509Certificates.StoreName
    public StoreName CertificateStoreName { get; set; }

    //
    // Summary:
    //     Skip discovery leg when connecting to Dataverse
    public bool SkipDiscovery { get; set; } = true;


    //
    // Summary:
    //     (Windows Only) If True, Uses the current user of windows to attempt the login
    //     with
    public bool UseCurrentUserForLogin { get; set; }

#endif
    }
}