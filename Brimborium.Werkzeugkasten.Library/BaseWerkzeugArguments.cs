namespace Brimborium.Werkzeugkasten.Library;

public class BaseWerkzeugArguments : DataverseConnectionSource {
    //public string? Action { get; set; }
}

public class BaseWerkzeugArgumentsUtility {
    public static string? GetConnectionString(IConfiguration configuration, BaseWerkzeugArguments? arguments=null) {
        if (arguments == null) { 
            arguments = new BaseWerkzeugArguments();
            configuration.Bind(arguments);
        }
        return configuration.GetConnectionString(arguments.ConnectionName);
    }
}