namespace Brimborium.Werkzeugkasten;

/// <summary>
/// Define the mapping between the source property and the target property.
/// </summary>
public sealed class WKMappingEntity {
    private WKMappingProperty? _PrimaryId;
    private readonly Dictionary<string, WKMappingProperty> _Mapping;

    /// <summary>
    /// The mapping of the primary key.
    /// </summary>
    public WKMappingProperty? PrimaryId {
        get {
            return this._PrimaryId;
        }

        set {
            this._PrimaryId = value;
        }
    }

    /// <summary>
    /// The mapping of the properties.
    /// </summary>
    public Dictionary<string, WKMappingProperty> Mapping => this._Mapping;

    public WKMappingEntity() {
        this._Mapping = new(StringComparer.OrdinalIgnoreCase);
    }

    public WKMappingEntity Copy() {
        WKMappingEntity result = new();
        result._PrimaryId = this._PrimaryId;
        foreach (var item in this._Mapping) {
            result._Mapping.Add(item.Key, item.Value);
        }
        return result;
    }

    public WKMappingEntity AddRangeMapping(IEnumerable<string>? listMapping) {
        if (listMapping is null) {
            return this;
        } else {
            foreach (var item in listMapping) {
                if (this._Mapping.ContainsKey(item)) {
                    // skip
                } else {
                    this._Mapping.Add(item, new(item));
                }
            }
            return this;
        }
    }

    public void AddRangeMappingProperty(IEnumerable<WKMappingProperty>? listMappingProperty) {
        if (listMappingProperty is null) {
            return;
        } else {
            foreach (var itemMappingProperty in listMappingProperty) {
                this._Mapping[itemMappingProperty.SourceProperty] = itemMappingProperty;
            }
        }
    }

    public List<WKMappingProperty> GetListMappingProperty() => new(this._Mapping.Values);

    public string GetTargetProperty(string sourceProperty)
        => (this._Mapping.TryGetValue(sourceProperty, out var item)
            && item.TargetProperty is { Length: > 0 } targetProperty)
            ? targetProperty
            : sourceProperty;

    /// <summary>
    /// Get the target property from the source property.
    /// </summary>
    /// <param name="key">source</param>
    /// <returns>target</returns>
    public string? this[string key] {
        get {
            if (this._Mapping.TryGetValue(key, out var value)) {
                return value.TargetProperty;
            } else {
                return null;
            }
        }
        set {
            if (value is null) {
                this._Mapping.Remove(key);
            } else {
                this._Mapping[key] = new WKMappingProperty(key, value);
            }
        }
    }

    public WKMappingEntity GetReverse() {
        WKMappingEntity result = new();
        foreach (var item in this._Mapping.Values) {
            var itemReverse = item.GetReverse();
            result._Mapping.Add(itemReverse.SourceProperty, itemReverse);
        }
        if (this._PrimaryId is not null) {
            result.PrimaryId = this._PrimaryId.GetReverse();
        }
        return result;
    }

    public WKMappingEntityAttributeToColumn GetMappingEntityAttributeToColumn(WKMetaEntity sourceMetaEntity, DataTable targetDataTable) {
        Dictionary<string, DataColumn> targetColumnByName = new(StringComparer.OrdinalIgnoreCase);
        foreach (DataColumn column in targetDataTable.Columns) {
            targetColumnByName[column.ColumnName] = column;
        }

        WKMappingPropertyAttributeToColumn? primaryId;
        List<WKMappingPropertyAttributeToColumn> listMappingProperty = new();

        {
            if ((this.PrimaryId is not null)
                && sourceMetaEntity.TryGetAttribute(this.PrimaryId.SourceProperty, out var sourceAttribute)
                && targetColumnByName.TryGetValue(this.PrimaryId.TargetProperty, out var targetPrimaryColumn)) {
                primaryId = new WKMappingPropertyAttributeToColumn(sourceAttribute, targetPrimaryColumn);
            } else {
                primaryId = null;
            }
        }

        {
            foreach (var itemMappingProperty in this._Mapping.Values) {
                if (sourceMetaEntity.TryGetAttribute(itemMappingProperty.SourceProperty, out var sourceAttribute)
                    && (sourceAttribute is not null)
                    && (targetColumnByName.TryGetValue(itemMappingProperty.TargetProperty, out var targetPrimaryColumn))
                    && (targetPrimaryColumn is not null)) {
                    listMappingProperty.Add(new WKMappingPropertyAttributeToColumn(sourceAttribute, targetPrimaryColumn));
                }
            }
        }

        return new WKMappingEntityAttributeToColumn(primaryId, listMappingProperty);
    }

    public WKMappingEntityColumnToAttribute GetMappingEntityColumnToAttribute(DataTable sourceDataTable, WKMetaEntity targetMetaEntity) {
        Dictionary<string, DataColumn> sourceColumnByName = new(StringComparer.OrdinalIgnoreCase);
        foreach (DataColumn column in sourceDataTable.Columns) {
            sourceColumnByName[column.ColumnName] = column;
        }

        WKMappingPropertyColumnToAttribute? primaryId;
        List<WKMappingPropertyColumnToAttribute> listMappingProperty = new();

        {
            if ((this.PrimaryId is not null)
                && targetMetaEntity.TryGetAttribute(this.PrimaryId.SourceProperty, out var targetAttribute)
                && sourceColumnByName.TryGetValue(this.PrimaryId.TargetProperty, out var sourcePrimaryColumn)) {
                primaryId = new WKMappingPropertyColumnToAttribute(sourcePrimaryColumn, targetAttribute);
            } else {
                primaryId = null;
            }
        }

        {
            foreach (var itemMappingProperty in this._Mapping.Values) {
                if (targetMetaEntity.TryGetAttribute(itemMappingProperty.SourceProperty, out var targetAttribute)
                    && (targetAttribute is not null)
                    && (sourceColumnByName.TryGetValue(itemMappingProperty.TargetProperty, out var sourcePrimaryColumn))
                    && (sourcePrimaryColumn is not null)) {
                    listMappingProperty.Add(new WKMappingPropertyColumnToAttribute(sourcePrimaryColumn, targetAttribute));
                }
            }
        }

        return new WKMappingEntityColumnToAttribute(primaryId, listMappingProperty);
    }

}

[method: System.Text.Json.Serialization.JsonConstructor]
public sealed record class WKMappingProperty(
    string SourceProperty,
    string TargetProperty
    ) {
    public WKMappingProperty(string name) : this(name, name) {
    }

    public WKMappingProperty GetReverse()
        => new(this.TargetProperty, this.SourceProperty);
}
//
public sealed record class WKMappingPropertyAttributeToColumn(
    AttributeMetadata SourceAttribute,
    DataColumn TargetColumn);

public sealed record class WKMappingEntityAttributeToColumn(
    WKMappingPropertyAttributeToColumn? PrimaryId,
    List<WKMappingPropertyAttributeToColumn> ListMappingProperty
    );
//
public sealed record class WKMappingPropertyColumnToAttribute(
    DataColumn SourceColumn,
    AttributeMetadata TargetAttribute);

public sealed record class WKMappingEntityColumnToAttribute(
    WKMappingPropertyColumnToAttribute? PrimaryId,
    List<WKMappingPropertyColumnToAttribute> ListMappingProperty);
//