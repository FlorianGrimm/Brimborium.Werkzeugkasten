namespace Brimborium.Werkzeugkasten.FileLogging;

public abstract class BatchLoggerConfigureOptions<TBatchingLoggerOptions> : IConfigureOptions<TBatchingLoggerOptions> 
    where TBatchingLoggerOptions: BatchingLoggerOptions {
    protected readonly IConfiguration _Configuration;
    protected bool _ConfigurationExists;

    protected BatchLoggerConfigureOptions(IConfiguration configuration) {
        this._Configuration = configuration;
        this._ConfigurationExists = (configuration is IConfigurationSection configurationSection) && configurationSection.Exists();
    }

    void IConfigureOptions<TBatchingLoggerOptions>.Configure(TBatchingLoggerOptions options) {
        this.Configure(options);
    }

    public virtual void Configure(TBatchingLoggerOptions options) {
        this._ConfigurationExists = (this._Configuration is IConfigurationSection configurationSection) && configurationSection.Exists();
        options.ConfigurationExists = this._ConfigurationExists;
    }

    protected static bool TextToBoolean(string? text) {
        if (string.IsNullOrEmpty(text) ||
            !bool.TryParse(text, out var result)) {
            result = false;
        }

        return result;
    }

    protected static TimeSpan? TextToTimeSpan(string? text, TimeSpan? defaultValue = default, Func<TimeSpan?, TimeSpan?>? convert = default) {
        if (string.IsNullOrEmpty(text) ||
            !TimeSpan.TryParse(text, out var result)) {
            if (convert is not null) {
                return convert(defaultValue);
            } else {
                return defaultValue;
            }
        } else {
            if (convert is not null) {
                return convert(result);
            } else {
                return result;
            }
        }
    }

    protected static int? TextToInt(string? text, int? defaultValue = default, Func<int?, int?>? convert = default) {
        if (string.IsNullOrEmpty(text) ||
            !int.TryParse(text, out var result)) {
            if (convert is not null) {
                return convert(defaultValue);
            } else {
                return defaultValue;
            }
        } else {
            if (convert is not null) {
                return convert(result);
            } else {
                return result;
            }
        }
    }
}
