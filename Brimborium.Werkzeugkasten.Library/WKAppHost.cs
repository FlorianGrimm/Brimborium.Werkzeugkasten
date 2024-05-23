namespace Brimborium.Werkzeugkasten;

public class WKAppHost {
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

    public void AddConfigurationUserSecrets(string name) {
        this.Configuration.AddUserSecrets(name);
    }
    public void AddConfigurationJsonFile(string name, bool optional) {
        this.Configuration.AddJsonFile(name, optional);
    }
    public void AddConfigurationInMemoryCollection(IEnumerable<KeyValuePair<string, string?>>? initialData) {
        this.Configuration.AddInMemoryCollection(initialData);
    }

    public WKAppHost ApplyHostConfiguration(
        string? configurationKeyHostBuilder = default,
        string? configurationKeyOpenTelemetry = default
        ) {
        var sectionKeyHostBuilder = string.IsNullOrEmpty(configurationKeyHostBuilder) ? "Host" : configurationKeyHostBuilder!;
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
            this._HostBuilder.Logging.ClearProviders();

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

    public void AddServiceSingleton(Type typeService, object instance) {
        if (instance is null) {
            this._HostBuilder.Services.AddSingleton(ServiceDescriptor.Singleton(typeService, typeService));
        } else if (instance is Type typeImplenation) {
            this._HostBuilder.Services.AddSingleton(ServiceDescriptor.Singleton(typeService, typeImplenation));
        } else if (typeService.IsAssignableFrom(instance.GetType())) {
            this._HostBuilder.Services.AddSingleton(ServiceDescriptor.Singleton(typeService, instance));
        } else {
            throw new ArgumentException($"{typeService.FullName} - {instance.GetType().FullName}", nameof(instance));
        }

    }

    public void AddLoggingConsole() {
        this._HostBuilder.Logging.AddConsole();
    }

    public void AddLoggingLocalFile() {
        this._HostBuilder.Logging.AddLocalFileLogger();
    }

    public void AddLoggingLocalFile1() {
        this._HostBuilder.Logging.AddLocalFileLogger1();
    }

    public void AddLoggingLocalFile2() {
        this._HostBuilder.Logging.AddLocalFileLogger2();
    }

    public void AddLoggingLocalFile3() {
        this._HostBuilder.Logging.AddLocalFileLogger3();
    }

    public void FlushLogger() {
        if (!(this._Host is { } host)) { return; }
        var listBatchingLoggerProvider = host.Services.GetServices<ILoggerProvider>()
            .OfType<BatchingLoggerProvider>();
        foreach (var batchingLoggerProvider in listBatchingLoggerProvider) {
            batchingLoggerProvider.Flush();
        }
    }

    public WKDataverseConnection? GetWKDataverseConnectionFromConfiguration(string name, ILogger? logger = default)
        => WKDataverseConnection.GetWKDataverseConnectionFromConfiguration(this, name, logger);

    public WKDataverseConnection GetWKDataverseConnectionFromConnectionString(WKDataverseConnectionString wkDataverseConnectionString, ILogger? logger = default)
        => WKDataverseConnection.GetWKDataverseConnectionFromConnectionString(this, wkDataverseConnectionString, logger);
}
