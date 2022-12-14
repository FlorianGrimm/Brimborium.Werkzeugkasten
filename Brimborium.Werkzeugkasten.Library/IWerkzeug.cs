namespace Brimborium.Werkzeugkasten.Library;

public interface IWerkzeug {
    Task<int> ExecuteAsync();
}

public record WerkzeugContext(
    IConfigurationRoot Confinguration,
    IServiceProvider ServiceProvider
    );