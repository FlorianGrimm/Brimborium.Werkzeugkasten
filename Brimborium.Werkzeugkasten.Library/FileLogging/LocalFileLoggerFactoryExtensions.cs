﻿namespace Brimborium.Werkzeugkasten.FileLogging;

public static class LocalFileLoggerFactoryExtensions {
    public static ILoggingBuilder AddLocalFileLogger(
        this ILoggingBuilder builder,
        IConfiguration? configuration = null) {
        //
        AddLocalFileLoggerInternal<LocalFileLoggerProvider, LocalFileLoggerOptions, LocalFileLoggerConfigureOptions>(
            builder, configuration, "Logging:LocalFile", (IConfiguration configuration) => new LocalFileLoggerConfigureOptions(configuration));
        AddLocalFileLoggerInternal<LocalFile1LoggerProvider, LocalFile1LoggerOptions, LocalFile1LoggerConfigureOptions>(
            builder, configuration, "Logging:LocalFile1", (IConfiguration configuration) => new LocalFile1LoggerConfigureOptions(configuration));
        AddLocalFileLoggerInternal<LocalFile2LoggerProvider, LocalFile2LoggerOptions, LocalFile2LoggerConfigureOptions>(
            builder, configuration, "Logging:LocalFile2", (IConfiguration configuration) => new LocalFile2LoggerConfigureOptions(configuration));
        AddLocalFileLoggerInternal<LocalFile3LoggerProvider, LocalFile3LoggerOptions, LocalFile3LoggerConfigureOptions>(
            builder, configuration, "Logging:LocalFile3", (IConfiguration configuration) => new LocalFile3LoggerConfigureOptions(configuration));
        //
        return builder;
    }
    private static void AddLocalFileLoggerInternal<TLocalFileLoggerProvider, TLocalFileLoggerOptions, TLocalFileLoggerConfigureOptions>(
        ILoggingBuilder builder,
        IConfiguration? configuration,
        string sectionKey,
        Func<IConfiguration, TLocalFileLoggerConfigureOptions> funcConfigureOptions)
        where TLocalFileLoggerProvider : class, ILoggerProvider
        where TLocalFileLoggerOptions : LocalFileBaseLoggerOptions
        where TLocalFileLoggerConfigureOptions : LocalFileBaseLoggerConfigureOptions<TLocalFileLoggerOptions> {
        var services = builder.Services;
        services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, TLocalFileLoggerProvider>());
        if (configuration is null) {
            services.AddSingleton<IConfigureOptions<TLocalFileLoggerOptions>>(
                (IServiceProvider serviceProvider) => {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>().GetSection(sectionKey);
                    return funcConfigureOptions(configuration);
                });
            services.AddSingleton<IOptionsChangeTokenSource<TLocalFileLoggerOptions>>(
                (IServiceProvider serviceProvider) => {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>().GetSection(sectionKey);
                    return new ConfigurationChangeTokenSource<TLocalFileLoggerOptions>(configuration);
                });
            LoggerProviderOptions.RegisterProviderOptions<TLocalFileLoggerOptions, TLocalFileLoggerProvider>(builder.Services);
        } else {
            if (configuration is IConfigurationRoot) {
                configuration = configuration.GetSection(sectionKey);
            }
            services.AddSingleton<IConfigureOptions<TLocalFileLoggerOptions>>(funcConfigureOptions(configuration));
            services.AddSingleton<IOptionsChangeTokenSource<TLocalFileLoggerOptions>>(
                new ConfigurationChangeTokenSource<TLocalFileLoggerOptions>(configuration));
            LoggerProviderOptions.RegisterProviderOptions<TLocalFileLoggerOptions, TLocalFileLoggerProvider>(builder.Services);
        }
    }
}
