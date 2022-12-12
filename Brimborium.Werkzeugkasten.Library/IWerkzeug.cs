namespace Brimborium.Werkzeugkasten.Library;

public interface IWerkzeug {
    Task<int> ExecuteAsync(WerkzeugContext context);
}

public record WerkzeugContext(
    IConfigurationBuilder ConfigurationBuilder,
    IConfigurationRoot Confinguration,
    ServiceCollection ServiceCollection,
    IServiceProvider ServiceProvider
    );