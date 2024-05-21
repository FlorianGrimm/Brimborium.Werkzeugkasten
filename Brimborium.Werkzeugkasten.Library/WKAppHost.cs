using Brimborium.Werkzeugkasten.FileLogging;

using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Brimborium.Werkzeugkasten;

public class WKAppHost {
    public static WKAppHost Create(
        string? applicationName = default,
        string? contentRootPath = default) {
        if (string.IsNullOrWhiteSpace(applicationName)) { applicationName = "Powershell"; }
        if (string.IsNullOrWhiteSpace(contentRootPath)) { contentRootPath = System.IO.Path.GetFullPath("."); }

        var settings = new Microsoft.Extensions.Hosting.HostApplicationBuilderSettings();
        settings.ApplicationName = applicationName;
        settings.ContentRootPath = contentRootPath;
        var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
        var result = new WKAppHost(hostBuilder);
        result._AppHostOption.ApplicationName = applicationName;
        result._AppHostOption.ContentRootPath = contentRootPath;
        return result;
    }

    protected Microsoft.Extensions.Hosting.HostApplicationBuilder _HostBuilder;
    protected Microsoft.Extensions.Hosting.IHost? _Host;
    protected WKAppHostOption _AppHostOption = new();
    protected OpenTelemetryOption _OpenTelemetryOption = new();
    protected OpenTelemetry.Resources.ResourceBuilder? _ResourceBuilder;

    public WKAppHost(Microsoft.Extensions.Hosting.HostApplicationBuilder? hostBuilder) {
        this._HostBuilder = hostBuilder ?? Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
    }

    public Microsoft.Extensions.Hosting.HostApplicationBuilder HostBuilder => this._HostBuilder;
    public ConfigurationManager Configuration => this._HostBuilder.Configuration;
    public OpenTelemetryOption OpenTelemetryOption => this._OpenTelemetryOption;
    public WKAppHostOption WKAppHostOption => this._AppHostOption;
    public Microsoft.Extensions.Hosting.IHost? Host => this._Host;

    public Microsoft.Extensions.Hosting.IHost GetHost() {
        if (this._Host is not null) { return this._Host; }
        var builder = this._HostBuilder;
        if (builder is null) { throw new Exception(); }
        return this._Host = builder.Build();
    }

    public WKAppHost AddConfigurationUserSecrets(string name) {
        this.Configuration.AddUserSecrets(name);
        return this;
    }
    public WKAppHost AddConfigurationJsonFile(string name, bool optional) {
        this.Configuration.AddJsonFile(name, optional);
        return this;
    }
    public WKAppHost AddConfigurationInMemoryCollection(IEnumerable<KeyValuePair<string, string?>>? initialData) {
        this.Configuration.AddInMemoryCollection(initialData);
        return this;
    }

    public WKAppHost ApplyHostConfiguration(
        string? configurationKeyHostBuilder = default,
        string? configurationKeyOpenTelemetry = default
        ) {
        var sectionKeyHostBuilder = string.IsNullOrEmpty(configurationKeyHostBuilder) ? "HostBuilder" : configurationKeyHostBuilder!;
        this._AppHostOption.Bind(this._HostBuilder.Configuration.GetSection(sectionKeyHostBuilder));
        var sectionKeyOpenTelemetry = string.IsNullOrEmpty(configurationKeyOpenTelemetry) ? "OpenTelemetry" : configurationKeyOpenTelemetry!;
        this._OpenTelemetryOption.Bind(this._HostBuilder.Configuration.GetSection(sectionKeyOpenTelemetry));

        if (this._AppHostOption.ApplicationName is { Length: > 0 } applicationName
            && !string.Equals(this._HostBuilder.Environment.ApplicationName, applicationName, StringComparison.Ordinal)) {
            this._HostBuilder.Environment.ApplicationName = applicationName;
        }
        if (this._AppHostOption.ContentRootPath is { Length: > 0 } contentRootPathOption
            && System.IO.Path.Combine(this._HostBuilder.Environment.ContentRootPath, contentRootPathOption) is { Length: > 0 } nextContentRootPath
            && !string.Equals(this._HostBuilder.Environment.ContentRootPath, nextContentRootPath, StringComparison.Ordinal)) {
            this._HostBuilder.Environment.ContentRootPath = nextContentRootPath;
        }
        if (this._AppHostOption.ConfigurationJsonFile is { Length: > 0 } arrConfigurationJsonFile) {
            foreach (var item in arrConfigurationJsonFile) {
                this.AddConfigurationJsonFile(item, true);
            }
        }
        if (this._AppHostOption.ConfigurationUserSecret is { Length: > 0 } arrConfigurationUserSecret) {
            foreach (var item in arrConfigurationUserSecret) {
                this.AddConfigurationUserSecrets(item);
            }
        }
        if (this._AppHostOption.EnableLogger is { Length: > 0 } arrEnableLogger) {
            foreach (var item in arrEnableLogger) {
                if (string.Equals(item, "Console", StringComparison.OrdinalIgnoreCase)) {
                    this._HostBuilder.Logging.AddConsole();
                    continue;
                }
                if (string.Equals(item, "LocalFile", StringComparison.OrdinalIgnoreCase)) {
                    this._HostBuilder.Logging.AddLocalFileLogger();
                    continue;
                }
                if (string.Equals(item, "LocalFile1", StringComparison.OrdinalIgnoreCase)) {
                    this._HostBuilder.Logging.AddLocalFileLogger1();
                    continue;
                }
                if (string.Equals(item, "LocalFile2", StringComparison.OrdinalIgnoreCase)) {
                    this._HostBuilder.Logging.AddLocalFileLogger2();
                    continue;
                }
                if (string.Equals(item, "LocalFile3", StringComparison.OrdinalIgnoreCase)) {
                    this._HostBuilder.Logging.AddLocalFileLogger3();
                    continue;
                }
                if (string.Equals(item, "OpenTelemetry", StringComparison.OrdinalIgnoreCase)) {
                    this._OpenTelemetryOption.EnableLogger = true;
                    continue;
                }
            }
        }


        if (this._OpenTelemetryOption.EnableLogger
            || this._OpenTelemetryOption.EnableTracing
            || this._OpenTelemetryOption.EnableMetrics
            ) {
            var resourceBuilder = (this._ResourceBuilder ??= this.CreateResourceBuilder(this._OpenTelemetryOption.Resource ??= new()));
            var openTelemetryBuilder = this._HostBuilder.Services.AddOpenTelemetry();

            bool useOtlpExporter;
            {
                if (this._OpenTelemetryOption.OtlpExporter is { } otlpExporter
                    && otlpExporter.Endpoint is { Length: > 0 } endpoint) {
                    openTelemetryBuilder.UseOtlpExporter(otlpExporter.Protocol.GetValueOrDefault(OtlpExportProtocol.HttpProtobuf), new Uri(endpoint));
                    useOtlpExporter = true;
                } else {
                    useOtlpExporter = false;
                }
            }

            if (!useOtlpExporter) {
                if (this._OpenTelemetryOption.EnableTracing) {
                    openTelemetryBuilder.WithTracing((tracerProviderBuilder) => {
                        tracerProviderBuilder.SetResourceBuilder(resourceBuilder);
                        if (this._OpenTelemetryOption.TracingOtlpExporter is { } sourceOtlpExporterOptions) {
                            tracerProviderBuilder.AddOtlpExporter(targetOtlpExporterOptions => {
                                CopyOtlpExporterOptions(sourceOtlpExporterOptions, targetOtlpExporterOptions);
                            });
                        }
                    });
                }

                if (this._OpenTelemetryOption.EnableMetrics) {
                    openTelemetryBuilder.WithMetrics((meterProviderBuilder) => {
                        meterProviderBuilder.SetResourceBuilder(resourceBuilder);
                        if (this._OpenTelemetryOption.MetricsOtlpExporter is { } sourceOtlpExporterOptions) {
                            meterProviderBuilder.AddOtlpExporter(targetOtlpExporterOptions => {
                                CopyOtlpExporterOptions(sourceOtlpExporterOptions, targetOtlpExporterOptions);
                            });
                        }
                    });
                }

                if (this._OpenTelemetryOption.EnableLogger) {
                    this._HostBuilder.Logging.AddOpenTelemetry((openTelemetryLoggerOptions) => {
                        openTelemetryLoggerOptions.SetResourceBuilder(resourceBuilder);
                        if (this._OpenTelemetryOption.LoggerOtlpExporter is { } sourceOtlpExporterOptions) {
                            openTelemetryLoggerOptions.AddOtlpExporter(targetOtlpExporterOptions => {
                                CopyOtlpExporterOptions(sourceOtlpExporterOptions, targetOtlpExporterOptions);
                            });
                        }
                    });
                }
            }
        }

        /*
        this._HostBuilder.Services.AddOpenTelemetry()
              .ConfigureResource(resource => resource.AddService(serviceName))
              .WithTracing(tracing => tracing
                  .AddAspNetCoreInstrumentation()
                  .AddConsoleExporter())
              .WithMetrics(metrics => metrics
                  .AddAspNetCoreInstrumentation()
                  .AddConsoleExporter());
        */
        return this;
    }

    private static void CopyOtlpExporterOptions(OtlpExporterOptions sourceOtlpExporterOptions, OtlpExporterOptions targetOtlpExporterOptions) {
        targetOtlpExporterOptions.Protocol = sourceOtlpExporterOptions.Protocol;
        targetOtlpExporterOptions.Headers = sourceOtlpExporterOptions.Headers;
        targetOtlpExporterOptions.Endpoint = sourceOtlpExporterOptions.Endpoint;
        targetOtlpExporterOptions.TimeoutMilliseconds = sourceOtlpExporterOptions.TimeoutMilliseconds;
        targetOtlpExporterOptions.BatchExportProcessorOptions = sourceOtlpExporterOptions.BatchExportProcessorOptions;
        targetOtlpExporterOptions.ExportProcessorType = sourceOtlpExporterOptions.ExportProcessorType;
    }

    protected OpenTelemetry.Resources.ResourceBuilder CreateResourceBuilder(OpenTelemetryResourceOption option, OpenTelemetry.Resources.ResourceBuilder? resourceBuilder = default) {
        var result = resourceBuilder ?? OpenTelemetry.Resources.ResourceBuilder.CreateEmpty();
        result.AddService(serviceName: option.ServiceName, serviceNamespace: option.ServiceNamespace, serviceVersion: option.ServiceVersion, autoGenerateServiceInstanceId: option.AutoGenerateServiceInstanceId, serviceInstanceId: option.ServiceInstanceId);
        return result;
    }


    public void FlushLogger() {
        if (this._Host is null) { return; }

        var listBatchingLoggerProvider = this._Host.Services.GetServices<ILoggerProvider>()
            .OfType<BatchingLoggerProvider>()
            ;
        foreach (var batchingLoggerProvider in listBatchingLoggerProvider) {
            batchingLoggerProvider.Flush();
        }
    }
}

public class WKAppHostOption {
    public WKAppHostOption() { }

    public string? ApplicationName { get; set; }

    public string? ContentRootPath { get; set; }

    public string[]? ConfigurationJsonFile { get; set; }

    public string[]? ConfigurationUserSecret { get; set; }

    public string[]? EnableLogger { get; set; }

    public void Bind(IConfiguration configuration) {
        if (configuration.GetValue<string?>(nameof(WKAppHostOption.ApplicationName), null) is { Length: > 0 } applicationName) {
            this.ApplicationName = applicationName;
        }
        if (configuration.GetValue<string?>(nameof(WKAppHostOption.ContentRootPath), null) is { Length: > 0 } contentRootPath) {
            this.ContentRootPath = contentRootPath;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.ConfigurationJsonFile), null) is { Length: > 0 } configurationJsonFile) {
            this.ConfigurationJsonFile = configurationJsonFile;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.ConfigurationUserSecret), null) is { Length: > 0 } configurationUserSecret) {
            this.ConfigurationUserSecret = configurationUserSecret;
        }
        if (configuration.GetValue<string[]?>(nameof(WKAppHostOption.EnableLogger), null) is { Length: > 0 } enableLogger) {
            this.EnableLogger = enableLogger;
        }
    }
}


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