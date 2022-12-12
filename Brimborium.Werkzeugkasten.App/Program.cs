namespace Brimborium.Werkzeugkasten.App;

public static class Program {
    public static async Task<int> Main(string[] args) {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddEnvironmentVariables();
        configurationBuilder.AddCommandLine(args);
        var configuration = DataverseConnectionSourceUtility.Resolve(configurationBuilder);
        var baseWerkzeugArguments = new BaseWerkzeugArguments();
        configuration.Bind(baseWerkzeugArguments);
        var connectionString = configuration.GetConnectionString(baseWerkzeugArguments.ConnectionName);

        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IConfigurationRoot>(configuration);
        services.AddOptions();

        // _ = services.AddOptions<ConnectionOptions>().Configure(confinguration.Bind);
        // TODO Load
        var location = typeof(Program).Assembly.Location;
        System.IO.DirectoryInfo? d = new System.IO.FileInfo(location).Directory;
        System.IO.DirectoryInfo? dirWerkzeug = default;
        while (d is not null && dirWerkzeug is null) {
            dirWerkzeug = d.EnumerateDirectories().FirstOrDefault(sd => sd.Name == "Werkzeug");
            d = d.Parent;
        }
        if (dirWerkzeug is not null) {
            var assemblyFiles = dirWerkzeug.EnumerateFiles("*.dll", SearchOption.AllDirectories);
            foreach (var file in assemblyFiles) {
                try {
                    var ass = System.Reflection.Assembly.Load(file.FullName);
                    System.Console.Out.Write(ass.FullName);
                } catch {
                }
            }
        }
        services.AddServicesWithRegistrator(null, null);
        var appServices = services.BuildServiceProvider();

        var valuePlugin = configuration.GetValue<string>("plugin");
        if (string.IsNullOrEmpty(valuePlugin)) {
            System.Console.Error.WriteLine($"--plugin '' is empty.");
            return -1;
        }
        var allPlugins = appServices.GetServices<IWerkzeug>();
        var pluginName = $"{valuePlugin}Werkzeug";
        var pluginsWithName = allPlugins.Where(plugin => plugin.GetType().Name == pluginName).ToList();
        if (pluginsWithName.Count == 0) {
            System.Console.Error.WriteLine($"--plugin '{pluginName}' not found");
            return -1;
        }
        if (pluginsWithName.Count > 1) {
            System.Console.Error.WriteLine($"--plugin '{pluginName}' found {pluginsWithName.Count} times.");
            foreach (var plugin in pluginsWithName) {
                System.Console.Error.WriteLine($"pluging {plugin.GetType().AssemblyQualifiedName}");
            }
            return -1;
        }

        try {
            var context = new WerkzeugContext(
                configurationBuilder,
                configuration,
                services,
                appServices
                );
            var werkzeug = pluginsWithName[0];
            return await werkzeug.ExecuteAsync(context);
        } catch (Exception error) {
            System.Console.Error.WriteLine(error.ToString());
            return -1;
        }
    }
}
