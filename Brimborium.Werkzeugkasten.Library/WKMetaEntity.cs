namespace Brimborium.Werkzeugkasten;

public sealed class WKMetaEntity {
    public static WKMetaEntity? Create(
        EntityMetadata? entity,
        List<AttributeMetadata> listAttribute) {
        if (entity is null || listAttribute is null) {
            return null;
        } else {
            return new WKMetaEntity(entity, listAttribute.ToArray(), null);
        }
    }

    private WKMetaEntity(
        EntityMetadata entity,
        AttributeMetadata[] listAttribute,
        WKMetaEntity? OriginalMetaEntity
        ) {
        var dictAttribute = listAttribute.ToDictionary(a => a.LogicalName, StringComparer.OrdinalIgnoreCase);
        this.Entity = entity;
        this.ListAttribute = listAttribute;
        this.DictAttribute = dictAttribute;
        this.OriginalMetaEntity = OriginalMetaEntity;
        _ = dictAttribute.TryGetValue(entity.PrimaryIdAttribute, out var metaId);
        _ = dictAttribute.TryGetValue("versionnumber", out var metaVersionnumber);
        this.ListAttributeData = listAttribute
            .Where(attribute => !(
                ReferenceEquals(attribute, metaId)
                || ReferenceEquals(attribute, metaVersionnumber)))
            .ToArray();
    }

    public WKMetaEntity(
        EntityMetadata entity,
        AttributeMetadata[] listAttribute
        ) : this(entity, listAttribute, null) { }

    public EntityMetadata Entity { get; }
    public AttributeMetadata[] ListAttribute { get; }
    public AttributeMetadata[] ListAttributeData { get; }
    public Dictionary<string, AttributeMetadata> DictAttribute { get; }
    public WKMetaEntity? OriginalMetaEntity { get; }
    public string LogicalName => this.Entity.LogicalName;
    public string PrimaryIdAttribute => this.Entity.PrimaryIdAttribute;

    public WKMetaEntity? GetRequired(string[] listColumn) {
        if (this.OriginalMetaEntity is not null) {
            return this.OriginalMetaEntity.GetRequired(listColumn);
        } else {
            var arrColumn = listColumn.ToArray();
            var hsColumnName = arrColumn.ToHashSet(System.StringComparer.OrdinalIgnoreCase);
            var listAttribute = this.ListAttribute
                .Where(attributeMetadata => hsColumnName.Contains(attributeMetadata.LogicalName))
                .ToArray();
            return new WKMetaEntity(this.Entity, listAttribute, this);
        }
    }

    public WKMappingEntity GetMappingEntity() {
        WKMappingEntity result = new();
        var primaryIdAttribute = this.PrimaryIdAttribute;
        if (!string.IsNullOrEmpty(primaryIdAttribute)) {
            result.PrimaryId = new WKMappingProperty(primaryIdAttribute);
        }
        result.AddRangeMapping(this.ListAttribute.Select(item => item.LogicalName));
        return result;
    }

    public Dictionary<string, WKMetaManyToManyRelationship> GetMetaManyToManyRelationshipByName() {
        Dictionary<string, WKMetaManyToManyRelationship> result = new(StringComparer.OrdinalIgnoreCase);
        foreach (var itemManyToManyRelationship in this.Entity.ManyToManyRelationships) {
            var item = new WKMetaManyToManyRelationship(itemManyToManyRelationship);
            result.Add(item.Name, item);
        }
        return result;
    }

    public Dictionary<string, WKMetaOneToManyRelationship> GetMetaOneToManyRelationshipByName() {
        Dictionary<string, WKMetaOneToManyRelationship> result = new(StringComparer.OrdinalIgnoreCase);
        foreach (var itemOneToManyRelationship in this.Entity.OneToManyRelationships) {
            var item = new WKMetaOneToManyRelationship(itemOneToManyRelationship);
            result.Add(item.Name, item);
        }
        return result;
    }

    public Dictionary<string, WKMetaManyToOneRelationship> GetMetaManyToOneRelationshipByName() {
        Dictionary<string, WKMetaManyToOneRelationship> result = new(StringComparer.OrdinalIgnoreCase);
        foreach (var itemManyToOneRelationship in this.Entity.ManyToOneRelationships) {
            var item = new WKMetaManyToOneRelationship(itemManyToOneRelationship);
            result.Add(item.Name, item);
        }
        return result;
    }

    public QueryExpression GetQueryExpression(bool addPrimaryIdAttribute, bool addVersionnumber) {
        var result = new QueryExpression(this.LogicalName);
        if (addPrimaryIdAttribute) {
            result.ColumnSet.AddColumn(this.PrimaryIdAttribute);
        }
        foreach (var attribute in this.ListAttribute) {
            if (attribute.IsValidForRead.GetValueOrDefault(false) && attribute.IsValidODataAttribute) {
                result.ColumnSet.AddColumn(attribute.LogicalName);
            }
        }
        if (addVersionnumber) {
            result.ColumnSet.AddColumn("versionnumber");
        }
        return result;
    }

    public EntityCollection CreateEntityCollection() {
        EntityCollection result = new();
        result.EntityName = this.LogicalName;
        return result;
    }

    public bool TryGetAttribute(string key, [MaybeNullWhen(false)] out AttributeMetadata value) {
        {
            if (this.DictAttribute.TryGetValue(key, out var attribute)) {
                value = attribute;
                return true;
            }
        }
        {
            foreach (var attribute in this.Entity.Attributes) {
                if (string.Equals(attribute.LogicalName, key, System.StringComparison.OrdinalIgnoreCase)) {
                    value = attribute;
                    return true;
                }
            }
        }
        {
            value = null;
            return false;
        }
    }
}

public abstract class WKMetaRelationship {
    protected WKMetaRelationship(RelationshipMetadataBase relationshipMetadataBase) {
        this.RelationshipMetadataBase = relationshipMetadataBase;
    }

    public string Name { get { return this.RelationshipMetadataBase.SchemaName; } }

    public RelationshipMetadataBase RelationshipMetadataBase { get; }

    public Relationship GetRelationship() => new Relationship(this.RelationshipMetadataBase.SchemaName);
}

public sealed class WKMetaManyToManyRelationship : WKMetaRelationship {
    public WKMetaManyToManyRelationship(ManyToManyRelationshipMetadata relationshipMetadata) : base(relationshipMetadata) {
        this.RelationshipMetadata = relationshipMetadata;
    }

    public ManyToManyRelationshipMetadata RelationshipMetadata { get; }
}

public sealed class WKMetaOneToManyRelationship : WKMetaRelationship {
    public WKMetaOneToManyRelationship(OneToManyRelationshipMetadata relationshipMetadata) : base(relationshipMetadata) {
        this.RelationshipMetadata = relationshipMetadata;
    }

    public OneToManyRelationshipMetadata RelationshipMetadata { get; }
}

public sealed class WKMetaManyToOneRelationship : WKMetaRelationship {
    public WKMetaManyToOneRelationship(OneToManyRelationshipMetadata relationshipMetadata) : base(relationshipMetadata) {
        this.RelationshipMetadata = relationshipMetadata;
    }

    public OneToManyRelationshipMetadata RelationshipMetadata { get; }
}
