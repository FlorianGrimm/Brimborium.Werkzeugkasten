using OpenTelemetry.Exporter;

namespace Brimborium.Werkzeugkasten;

public class OpenTelemetryOption {
    public OpenTelemetryResourceOption? Resource { get; set; } = new();
    public bool EnableLogger { get; set; }
    public OtlpExporterOptions? LoggerOtlpExporter { get; set; }
    public bool EnableTracing { get; set; }
    public OtlpExporterOptions? TracingOtlpExporter { get; set; }
    public bool EnableMetrics { get; set; }
    public OtlpExporterOptions? MetricsOtlpExporter { get; set; }
    public OpenTelemetryCommonOtlpExporterOptions? OtlpExporter { get; set; }

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<bool?>(nameof(OpenTelemetryOption.EnableLogger), null) is bool enableLogger) {
            this.EnableLogger = enableLogger;
        }
        if (configuration.GetValue<bool?>(nameof(OpenTelemetryOption.EnableTracing), false) is bool enableTracing) {
            this.EnableTracing = enableTracing;
        }
        if (configuration.GetValue<bool?>(nameof(OpenTelemetryOption.EnableMetrics), false) is bool enableMetrics) {
            this.EnableMetrics = enableMetrics;
        }
        if (configuration.GetSection(nameof(OpenTelemetryOption.Resource)) is IConfiguration resourceConfiguration) {
            this.Resource ??= new();
            this.Resource.Bind(resourceConfiguration);
        }

    }
}
public class OpenTelemetryResourceOption {
    public string ServiceName { get; set; } = string.Empty;
    public string? ServiceNamespace { get; set; } = null;
    public string? ServiceVersion { get; set; } = null;
    public bool AutoGenerateServiceInstanceId { get; set; } = true;
    public string? ServiceInstanceId { get; set; } = null;

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<string?>(nameof(OpenTelemetryResourceOption.ServiceName), default) is { Length: > 0 } serviceName) {
            this.ServiceName = serviceName;
        }
        if (configuration.GetValue<string?>(nameof(OpenTelemetryResourceOption.ServiceNamespace), default) is { Length: > 0 } serviceNamespace) {
            this.ServiceNamespace = serviceNamespace;
        }
        if (configuration.GetValue<string?>(nameof(OpenTelemetryResourceOption.ServiceVersion), default) is { Length: > 0 } serviceVersion) {
            this.ServiceVersion = serviceVersion;
        }
        {
            if (configuration.GetValue<string?>(nameof(OpenTelemetryResourceOption.ServiceInstanceId), default) is { Length: > 0 } serviceInstanceId) {
                this.ServiceInstanceId = serviceInstanceId;
                this.AutoGenerateServiceInstanceId = false;
            } else {
                this.AutoGenerateServiceInstanceId = true;
            }
        }
    }
}

public class OpenTelemetryCommonOtlpExporterOptions {
    public OpenTelemetryCommonOtlpExporterOptions() { }

    public OtlpExportProtocol? Protocol { get; set; }
    public string? Endpoint { get; set; }

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<OtlpExporterOptions?>(nameof(OpenTelemetryCommonOtlpExporterOptions.Protocol), default) is { } protocol) {
            this.Protocol = protocol.Protocol;
        }
        if (configuration.GetValue<string?>(nameof(OpenTelemetryCommonOtlpExporterOptions.Endpoint), default) is { Length: > 0 } endpoint) {
            this.Endpoint = endpoint;
        }
    }
}