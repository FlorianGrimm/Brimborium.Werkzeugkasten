using System.Security;

namespace Brimborium.Werkzeugkasten.Powershell;

[Cmdlet(VerbsCommon.New, nameof(WKDataverseConnectionString),
    ConfirmImpact = ConfirmImpact.None,
    DefaultParameterSetName = nameof(ConnectionString),
    SupportsShouldProcess = false,
    SupportsTransactions = false)]
[OutputType(typeof(WKDataverseConnectionString))]
public sealed class NewWKDataverseConnectionStringCmdlet : PSCmdlet {
    [Parameter(Position = 0, ParameterSetName = nameof(ConnectionString))]
    public string? ConnectionString { get; set; }

    [Parameter(Position = 0, ParameterSetName = nameof(WKDataverseConnectionString))]
    public Microsoft.PowerPlatform.Dataverse.Client.AuthenticationType? AuthenticationType { get; set; }

    [Parameter(Position = 1, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? ServiceUri { get; set; }

    [Parameter(Position = 2, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? UserName { get; set; }

    [Parameter(Position = 3, ParameterSetName = nameof(WKDataverseConnectionString))]
    public SecureString? Password { get; set; }

    [Parameter(Position = 4, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? Domain { get; set; }

    [Parameter(Position = 5, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? HomeRealmUri { get; set; }

    [Parameter(Position = 6, ParameterSetName = nameof(WKDataverseConnectionString))]
    public bool? RequireNewInstance { get; set; } = true;

    //
    // Summary:
    //     Client \ Application ID to be used when logging into Dataverse.
    [Parameter(Position = 7, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? ClientId { get; set; } // = DataverseConnectionStringProcessor.sampleClientId;

    //
    // Summary:
    //     Client Secret Id to use to login to Dataverse
    [Parameter(Position = 8, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? ClientSecret { get; set; }

    //
    // Summary:
    //     Redirect Uri to use when connecting to dataverse. Required for OAuth Authentication.
    [Parameter(Position = 9, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? RedirectUri { get; set; } // = new Uri(DataverseConnectionStringProcessor.sampleRedirectUrl);

    //
    // Summary:
    //     Path and FileName for MSAL Token Cache. Used only for OAuth - User Interactive
    //     flows.
    [Parameter(Position = 10, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? TokenCacheStorePath { get; set; }

    //
    // Summary:
    //     Type of Login prompt to use.
    [Parameter(Position = 11, ParameterSetName = nameof(WKDataverseConnectionString))]
    public PromptBehavior? LoginPrompt { get; set; }

    //
    // Summary:
    //     Certificate ThumbPrint to use to lookup machine certificate to use for authentication.
    [Parameter(Position = 12, ParameterSetName = nameof(WKDataverseConnectionString))]
    public string? CertificateThumbprint { get; set; }

    //
    // Summary:
    //     Certificate store name to look up thumbprint. System.Security.Cryptography.X509Certificates.StoreName
    [Parameter(Position = 13, ParameterSetName = nameof(WKDataverseConnectionString))]
    public System.Security.Cryptography.X509Certificates.StoreName? CertificateStoreName { get; set; }

    //
    // Summary:
    //     Skip discovery leg when connecting to Dataverse
    [Parameter(Position = 14, ParameterSetName = nameof(WKDataverseConnectionString))]
    public bool? SkipDiscovery { get; set; } = true;

    //
    // Summary:
    //     (Windows Only) If True, Uses the current user of windows to attempt the login
    //     with
    public bool? UseCurrentUserForLogin { get; set; }

    protected override void BeginProcessing() {
        var result = new WKDataverseConnectionString();
        if (string.Equals(this.ParameterSetName, nameof(ConnectionString), StringComparison.Ordinal)) {
            result.ConnectionString = this.ConnectionString;
            this.WriteObject(result);
            return;
        }

        if (string.Equals(this.ParameterSetName, nameof(WKDataverseConnectionString), StringComparison.Ordinal)) {
            if (this.AuthenticationType is { } authenticationType) {
                result.AuthenticationType = authenticationType;
            }
            if (this.ServiceUri is { Length: > 0 } serviceUri) {
                result.ServiceUri = new Uri(serviceUri, UriKind.Absolute);
            }
            if (this.UserName is { } userName) {
                result.UserName = userName;
            }
            if (this.Password is { } password) {
                result.Password = password;
            }
            if (this.Domain is { } domain) {
                result.Domain = domain;
            }
            if (this.HomeRealmUri is { Length: > 0 } homeRealmUri) {
                result.HomeRealmUri = new Uri(homeRealmUri, UriKind.Absolute);
            }
            if (this.RequireNewInstance is { } requireNewInstance) {
                result.RequireNewInstance = requireNewInstance;
            }
            if (this.ClientId is { } clientId) {
                result.ClientId = clientId;
            }
            if (this.ClientSecret is { } clientSecret) {
                result.ClientSecret = clientSecret;
            }
            if (this.RedirectUri is { } redirectUri) {
                result.RedirectUri = new Uri(redirectUri, UriKind.Absolute);
            }
            if (this.TokenCacheStorePath is { } tokenCacheStorePath) {
                result.TokenCacheStorePath = tokenCacheStorePath;
            }
            if (this.LoginPrompt is { } loginPrompt) {
                result.LoginPrompt = loginPrompt;
            }
            if (this.CertificateThumbprint is { } certificateThumbprint) {
                result.CertificateThumbprint = certificateThumbprint;
            }
            if (this.CertificateStoreName is { } certificateStoreName) {
                result.CertificateStoreName = certificateStoreName;
            }
            if (this.SkipDiscovery is { } skipDiscovery) {
                result.SkipDiscovery = skipDiscovery;
            }
            this.WriteObject(result);
            return;
        }

        {
            this.WriteObject(result);
            return;
        }
    }
}