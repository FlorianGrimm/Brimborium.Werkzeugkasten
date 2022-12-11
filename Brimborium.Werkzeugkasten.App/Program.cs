namespace Brimborium.Werkzeugkasten.App;

public static class Program {
    public static int Main(string[] args) {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddEnvironmentVariables();
        configurationBuilder.AddCommandLine(args);
        var confinguration = configurationBuilder.Build();

        var services =new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddOptions();
        var appServices = services.BuildServiceProvider();
        

        return 0;
    }
}
