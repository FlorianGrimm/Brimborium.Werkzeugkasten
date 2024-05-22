namespace Brimborium.Werkzeugkasten;

public static partial class WKUtility {

    /// <summary>
    /// Serialize MappingEntity to JSON-string.
    /// </summary>
    /// <param name="mappingEntity">instance to serialize</param>
    /// <returns>json</returns>
    public static string SerializeWKMappingEntityToJson(WKMappingEntity mappingEntity)
            => JsonSerializer.Serialize(
                mappingEntity,
                typeof(WKMappingEntity),
                WKJsonSerializerContext.Default);

    /// <summary>
    /// Deserialize MappingEntity from JSON-string.
    /// </summary>
    /// <param name="json">JSON string</param>
    /// <returns>deserialized json - instance</returns>
    public static WKMappingEntity? DeserializeWKMappingEntityFromJson(string? json)
        => (string.IsNullOrEmpty(json))
            ? default
            : ((WKMappingEntity?)JsonSerializer.Deserialize(
                json!,
                typeof(WKMappingEntity),
                WKJsonSerializerContext.Default));
}


[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(WKMappingEntity))]
[JsonSerializable(typeof(WKMappingProperty))]
internal partial class WKJsonSerializerContext : JsonSerializerContext {
}
