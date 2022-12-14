namespace Brimborium.Werkzeugkasten.Library;

public class BootApp {
    public static async Task<int> RunAsync<T>(
        string[] args,
        System.Reflection.Assembly? assembly=null
        )
        where T : IWerkzeug {
        var bootApp = new BootApp(args);
        if (assembly is not null) { 
            bootApp.ConfigurationBuilder.AddUserSecrets(assembly);
        }
        bootApp.BuildConfiguration();
        bootApp.Services.AddServicesWithRegistrator(null, null);
        bootApp.BuildServiceProvider();
        return await bootApp.ExecuteAsync<T>();
    }

    public ConfigurationBuilder ConfigurationBuilder { get; }
    public IConfigurationRoot Configuration { get; protected set; }
    public ServiceCollection Services { get; }
    public IServiceProvider ServiceProvider { get; protected set; }

    public BootApp() {
        this.ConfigurationBuilder = new ConfigurationBuilder();
        this.Configuration = new FailingConfigurationRoot();
        this.Services = new ServiceCollection();
        this.ServiceProvider = new FailingServiceProvider();
    }

    public BootApp(string[] args) : this() {
        this.ConfigurationBuilder.AddEnvironmentVariables();
        this.ConfigurationBuilder.AddCommandLine(args);
    }

    public virtual IConfigurationRoot BuildConfiguration() {
        // Initialize the configuration
        var configuration = DataverseConnectionSourceUtility.Resolve(this.ConfigurationBuilder);
        this.Configuration = configuration;
        this.Services.AddSingleton<IConfigurationRoot>(configuration);
        this.Services.AddOptions();
        return configuration;
    }

    public virtual ServiceProvider BuildServiceProvider() {
        if (this.Configuration is FailingConfigurationRoot) {
            this.BuildConfiguration();
        }
        var serviceProvider = this.Services.BuildServiceProvider();
        this.ServiceProvider = serviceProvider;
        return serviceProvider;
    }

    public async Task<int> ExecuteAsync<T>()
        where T : IWerkzeug {
        if (this.ServiceProvider is FailingServiceProvider) {
            this.BuildServiceProvider();
        }
        var plugin = this.ServiceProvider.GetRequiredService<T>();
        return await plugin.ExecuteAsync();
    }

    public class FailingConfigurationRoot : IConfigurationRoot {
        public string? this[string key] { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        public IEnumerable<IConfigurationProvider> Providers => throw new NotSupportedException();

        public IEnumerable<IConfigurationSection> GetChildren() => throw new NotSupportedException();

        public IChangeToken GetReloadToken() => throw new NotSupportedException();

        public IConfigurationSection GetSection(string key) => throw new NotSupportedException();

        public void Reload() => throw new NotSupportedException();
    }

    public class FailingServiceProvider : IServiceProvider {
        public object? GetService(Type serviceType) => throw new NotSupportedException();
    }
}