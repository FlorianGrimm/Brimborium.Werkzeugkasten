namespace Brimborium.Werkzeugkasten.App;

public static class Program {
    public static async Task<int> Main(string[] args) {
        var bootApp = new BootApp(args);
        var configuration = bootApp.BuildConfiguration();

        // WEICHEI?
        // var baseWerkzeugArguments = new BaseWerkzeugArguments();
        // configuration.Bind(baseWerkzeugArguments);
        // var connectionString = configuration.GetConnectionString(baseWerkzeugArguments.ConnectionName);
        // _ = services.AddOptions<ConnectionOptions>().Configure(confinguration.Bind);

        LoadAssemblies();

        bootApp.Services.AddServicesWithRegistrator(null, null);

        var appServices = bootApp.BuildServiceProvider();
        var (werkzeug, errorMessage) = GetWerkzeug(configuration, appServices);
        if (errorMessage is not null) {
            System.Console.Error.WriteLine(errorMessage);
            return -1;
        }
        if (werkzeug is null) {
            System.Console.Error.WriteLine("No werkzeug found.");
            return -1;
        }
        try {
            return await werkzeug.ExecuteAsync();
        } catch (Exception error) {
            System.Console.Error.WriteLine(error.ToString());
            return -1;
        }
    }

    private static void LoadAssemblies() {
        var location = typeof(Program).Assembly.Location;
        DirectoryInfo? d = new FileInfo(location).Directory;
        DirectoryInfo? dirWerkzeug = default;
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
    }

    private static (IWerkzeug? plugin, string? errorMessage) GetWerkzeug(IConfigurationRoot configuration, ServiceProvider appServices) {
        var valuePlugin = configuration.GetValue<string>("plugin");
        if (string.IsNullOrEmpty(valuePlugin)) {
            return(null, $"--plugin '' is empty.");
        }
        var allPlugins = appServices.GetServices<IWerkzeug>();
        var pluginName = $"{valuePlugin}Werkzeug";
        var pluginsWithName = allPlugins.Where(plugin => plugin.GetType().Name == pluginName).ToList();
        if (pluginsWithName.Count == 0) {
            return (null, $"--plugin '{pluginName}' not found");
            
        }
        if (pluginsWithName.Count > 1) {
            var sb = new StringBuilder();
            sb.AppendLine($"--plugin '{pluginName}' found {pluginsWithName.Count} times.");
            foreach (var plugin in pluginsWithName) {
                sb.AppendLine($"pluging {plugin.GetType().AssemblyQualifiedName}");
            }
            return (null, sb.ToString());
        }
        var werkzeug = pluginsWithName.FirstOrDefault();
        return (werkzeug, null);
    }
}
