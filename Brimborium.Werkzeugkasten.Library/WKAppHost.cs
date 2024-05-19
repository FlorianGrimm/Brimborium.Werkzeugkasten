namespace Brimborium.Werkzeugkasten;

public class WKAppHost {
    protected Microsoft.Extensions.Hosting.HostApplicationBuilder? _HostBuilder;
    protected Microsoft.Extensions.Hosting.IHost? _Host;

    public WKAppHost() {
        this._HostBuilder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
    }

    public Microsoft.Extensions.Hosting.HostApplicationBuilder? HostBuilder => this._HostBuilder;

    public Microsoft.Extensions.Hosting.IHost? Host => this._Host;

    public Microsoft.Extensions.Hosting.IHost GetHost() {
        if (this._Host is not null) { return this._Host; }
        var builder = this._HostBuilder;
        if (builder is null) { throw new Exception(); }
        this._HostBuilder = null;
        return this._Host = builder.Build();
    }
}

