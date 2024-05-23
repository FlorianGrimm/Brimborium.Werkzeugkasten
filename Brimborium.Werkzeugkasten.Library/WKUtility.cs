namespace Brimborium.Werkzeugkasten;

public static partial class WKUtility {
    public static string? NullIf(string? value, string? comparision = default) {
        if (value is { Length: > 0 }) {
            if (comparision is not null && string.Equals(value, comparision, StringComparison.Ordinal)) {
                return null;
            }
            return value;
        } else {
            return null;
        }
    }

    public static string GetValueOrDefault(this string? value, string defaultValue) {
        if (value is { Length: > 0 }) {
            return value;
        } else {
            return defaultValue;
        }
    }
}
