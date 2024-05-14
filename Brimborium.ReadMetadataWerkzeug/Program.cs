namespace Brimborium.ReadMetadataWerkzeug;

public static class Program {
    public static async Task<int> Main(string[] args) {
        return await BootApp.RunAsync<MetadataWerkzeug>(args, typeof(Program).Assembly);
    }
}
