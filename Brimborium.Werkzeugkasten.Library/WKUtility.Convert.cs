namespace Brimborium.Werkzeugkasten;
public static partial class WKUtility {
    public const string Versionnumber = "versionnumber";

    /// <summary>
    /// Convert a dataverse value (with attribute) to a (normal) value.
    /// </summary>
    /// <param name="attribute">the related attribute</param>
    /// <param name="value">dataverse value</param>
    /// <returns>the converted value</returns>
    /// <exception cref="InvalidDataException"></exception>
    public static object? ConvertFromAttributeValue(AttributeMetadata attribute, object? value) {
        if (value is null) {
            // if value is null, return null
            return value;
        }
        {
            if (attribute is not null) {
                // depending on the attribute type, convert the value
                switch (attribute.AttributeType) {
                    case AttributeTypeCode.Boolean: {
                            // BooleanAttributeMetadata
                            return (value is bool valueBool) && valueBool;
                        }
                    case AttributeTypeCode.DateTime: {
                            // DateTimeAttributeMetadata
                            if (value is DateTime valueDateTime) {
                                return valueDateTime;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.Decimal: {
                            // DecimalAttributeMetadata
                            if (value is Decimal valueDecimal) {
                                return valueDecimal;
                            } else if (value is Double valueDouble) {
                                return (Decimal)valueDouble;
                            } else if (value is Single valueSingle) {
                                return (Decimal)valueSingle;
                            } else if (value is Int32 valueInt32) {
                                return (Decimal)valueInt32;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.Double: {
                            // DoubleAttributeMetadata
                            if (value is Double valueDouble) {
                                return valueDouble;
                            } else if (value is Decimal valueDecimal) {
                                return (double)valueDecimal;
                            } else if (value is Single valueSingle) {
                                return (double)valueSingle;
                            } else if (value is Int32 valueInt32) {
                                return (double)valueInt32;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.Integer: {
                            // IntegerAttributeMetadata
                            if (value is Int32 valueInt32) {
                                return valueInt32;
                            } else if (value is Double valueDouble) {
                                return (int)valueDouble;
                            } else if (value is Decimal valueDecimal) {
                                return (int)valueDecimal;
                            } else if (value is Single valueSingle) {
                                return (int)valueSingle;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.Memo: {
                            if (attribute is MemoAttributeMetadata memoAttributeMetadata) {
                                if (value is string valueString) {
                                } else {
                                    valueString = value!.ToString()!;
                                }
                                return valueString;
                            } else {
                                throw new InvalidDataException($"attribute({attribute.LogicalName}) is not a MemoAttributeMetadata is a {attribute.GetType().FullName}");
                            }
                        }
                    case AttributeTypeCode.Money: {
                            // MoneyAttributeMetadata
                            if (value is Money valueMoney) {
                                return valueMoney.Value;
                            } else if (value is System.Decimal valueDecimal) {
                                return valueDecimal;
                            } else if (value is System.Double valueDouble) {
                                return (decimal)valueDouble;
                            } else if (value is System.Single valueSingle) {
                                return (decimal)valueSingle;
                            } else if (value is int valueInt) {
                                return (decimal)valueInt;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.PartyList: {
                            // MultiSelectPicklistAttributeMetadata
                            // ImageAttributeMetadata
                            // FileAttributeMetadata
                            return value;
                        }
                    case AttributeTypeCode.Picklist:
                    case AttributeTypeCode.State:
                    case AttributeTypeCode.Status: {
                            // StateAttributeMetadata
                            // StatusAttributeMetadata
                            // PicklistAttributeMetadata

                            if (value is OptionSetValue optionSetValue) {
                                return optionSetValue.Value;
                            } else if (value is int valueInt) {
                                return valueInt;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.String: {
                            // StringAttributeMetadata
                            if (value is string valueString) {
                                return valueString;
                            } else {
                                return value!.ToString()!;
                            }
                        }
                    case AttributeTypeCode.Uniqueidentifier: {
                            // UniqueIdentifierAttributeMetadata
                            if (value is Guid valueGuid) {
                                return valueGuid;
                            } else {
                                if (value?.ToString() is string valueString
                                    && Guid.TryParse(valueString, out valueGuid)) {
                                    return valueGuid;
                                } else {
                                    return value;
                                }
                            }
                        }
                    case AttributeTypeCode.CalendarRules: {
                            return value;
                        }
                    case AttributeTypeCode.Virtual: {
                            return value;
                        }
                    case AttributeTypeCode.BigInt: {
                            // BigIntAttributeMetadata
                            if (value is Int64 valueInt64) {
                                return valueInt64;
                            } else if (value is Int32 valueInt32) {
                                return (Int64)valueInt32;
                            } else {
                                if (value?.ToString() is string valueString
                                    && Int64.TryParse(valueString, out valueInt64)) {
                                    return valueInt64;
                                } else {
                                    return value;
                                }
                            }
                        }
                    case AttributeTypeCode.Lookup:
                    case AttributeTypeCode.Customer:
                    case AttributeTypeCode.Owner: {
                            if (value is Guid guidLookup) {
                                return guidLookup;
                            } else if (value is EntityReference entityReference) {
                                return entityReference.Id;
                            } else {
                                return value;
                            }
                        }
                    case AttributeTypeCode.ManagedProperty: {
                            // ManagedPropertyAttributeMetadata
                            return value;
                        }
                    case AttributeTypeCode.EntityName: {
                            // EntityNameAttributeMetadata
                            return value;
                        }
                    default:
                        return value;
                }
            }
        }
        {
            // if not attribute is provided, return the value as based on the type
            if (value is string valueString) {
                return valueString;
            } else if (value is Money money) {
                return money.Value;
            } else if (value is OptionSetValue optionSetValue) {
                return optionSetValue.Value;
            } else if (value is EntityReference entityReference) {
                return entityReference.Id;
            } else if (value is Microsoft.Xrm.Sdk.AliasedValue aliasedValue) {
                return aliasedValue.Value;
            } else {
                return value;
            }
        }
    }

    /// <summary>
    /// Convert a (normal) value to a dataverse value (with attribute).
    /// </summary>
    /// <param name="attribute">the related attribute</param>
    /// <param name="value">the (normal) value</param>
    /// <returns>the (dataverse) value.</returns>
    /// <exception cref="InvalidDataException"></exception>
    public static object? ConvertToAttributeValue(AttributeMetadata attribute, object? value) {
        if ((value is null) || (attribute is null)) {
            // if value is null, return null
            return value;
        }
        {
            // depending on the attribute type, convert the value
            switch (attribute.AttributeType) {
                case AttributeTypeCode.Boolean: {
                        // BooleanAttributeMetadata
                        return (value is bool valueBool) && valueBool;
                    }
                case AttributeTypeCode.DateTime: {
                        // DateTimeAttributeMetadata
                        if (value is DateTime valueDateTime) {
                            return valueDateTime;
                        } else {
                            return null;
                        }
                    }
                case AttributeTypeCode.Decimal: {
                        // DecimalAttributeMetadata
                        if (value is Decimal valueDecimal) {
                            return valueDecimal;
                        } else if (value is Double valueDouble) {
                            return (Decimal)valueDouble;
                        } else if (value is Single valueSingle) {
                            return (Decimal)valueSingle;
                        } else if (value is Int32 valueInt32) {
                            return (Decimal)valueInt32;
                        } else {
                            return value;
                        }
                    }
                case AttributeTypeCode.Double: {
                        // DoubleAttributeMetadata
                        if (value is Double valueDouble) {
                            return valueDouble;
                        } else if (value is Decimal valueDecimal) {
                            return (double)valueDecimal;
                        } else if (value is Single valueSingle) {
                            return (double)valueSingle;
                        } else if (value is Int32 valueInt32) {
                            return (double)valueInt32;
                        } else {
                            return value;
                        }
                    }
                case AttributeTypeCode.Integer: {
                        // IntegerAttributeMetadata
                        if (value is Int32 valueInt32) {
                            return valueInt32;
                        } else if (value is Double valueDouble) {
                            return (int)valueDouble;
                        } else if (value is Decimal valueDecimal) {
                            return (int)valueDecimal;
                        } else if (value is Single valueSingle) {
                            return (int)valueSingle;
                        } else {
                            return value;
                        }
                    }
                case AttributeTypeCode.Memo: {
                        if (attribute is MemoAttributeMetadata memoAttributeMetadata) {
                            if (value is string valueString) {
                            } else {
                                valueString = value!.ToString()!;
                            }
                            return valueString;
                        } else {
                            throw new InvalidDataException($"attribute({attribute.LogicalName}) is not a MemoAttributeMetadata is a {attribute.GetType().FullName}");
                        }
                    }
                case AttributeTypeCode.Money: {
                        // MoneyAttributeMetadata
                        if (value is System.Decimal valueDecimal) {
                            return new Money(valueDecimal);
                        } else if (value is System.Double valueDouble) {
                            return new Money((decimal)valueDouble);
                        } else if (value is System.Single valueSingle) {
                            return new Money((decimal)valueSingle);
                        } else if (value is int valueInt) {
                            return new Money((decimal)valueInt);
                        } else {
                            return null;
                        }
                    }
                case AttributeTypeCode.PartyList: {
                        // MultiSelectPicklistAttributeMetadata
                        // ImageAttributeMetadata
                        // FileAttributeMetadata
                        return value;
                    }
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status: {
                        // StateAttributeMetadata
                        // StatusAttributeMetadata
                        // PicklistAttributeMetadata

                        if (value is OptionSetValue optionSetValue) {
                            return optionSetValue;
                        } else if (value is int valueInt) {
                            return new OptionSetValue(valueInt);
                        } else {
                            return null;
                        }
                    }
                case AttributeTypeCode.String: {
                        // StringAttributeMetadata
                        if (value is string valueString) {
                        } else {
                            valueString = value!.ToString()!;
                        }
                        return valueString;
                    }
                case AttributeTypeCode.Uniqueidentifier: {
                        // UniqueIdentifierAttributeMetadata
                        if (value is Guid valueGuid) {
                            return valueGuid;
                        } else {
                            if (value?.ToString() is string valueString
                                && Guid.TryParse(valueString, out valueGuid)) {
                                return valueGuid;
                            } else {
                                return value;
                            }
                        }
                    }
                case AttributeTypeCode.CalendarRules: {
                        return value;
                    }
                case AttributeTypeCode.Virtual: {
                        return value;
                    }
                case AttributeTypeCode.BigInt: {
                        // BigIntAttributeMetadata
                        if (value is Int64 valueInt64) {
                            return valueInt64;
                        } else if (value is Int32 valueInt32) {
                            return (Int64)valueInt32;
                        } else {
                            if (value?.ToString() is string valueString
                                && Int64.TryParse(valueString, out valueInt64)) {
                                return valueInt64;
                            } else {
                                return value;
                            }
                        }
                    }
                case AttributeTypeCode.Lookup:
                case AttributeTypeCode.Customer:
                case AttributeTypeCode.Owner: {
                        if (attribute is LookupAttributeMetadata lookupAttributeMetadata) {
                            /*
                                AttributeTypeCode.Customer
                                AttributeTypeCode.Lookup
                                AttributeTypeCode.Owner
                             */
                            if (value is Guid guidLookup) {
                                return new EntityReference(lookupAttributeMetadata.Targets[0], guidLookup);
                            } else {
                                return null;
                            }
                        } else {
                            throw new InvalidDataException($"attribute({attribute.LogicalName}) is not a LookupAttributeMetadata is a {attribute.GetType().FullName}");
                        }
                    }
                case AttributeTypeCode.ManagedProperty: {
                        // ManagedPropertyAttributeMetadata
                        return value;
                    }
                case AttributeTypeCode.EntityName: {
                        // EntityNameAttributeMetadata
                        return value;
                    }
                default:
                    return value;
            }
        }
    }

    //
    public static long CopyToDataTable(
        WKMetaEntity metaEntity,
        EntityCollection inputCollection,
        DataTable outputDataTable,
        WKMappingEntityAttributeToColumn mappingEntityAttributeToColumn) {
        System.Int64 result = 0;
        var metaEntityContainsVersionNumber = metaEntity.DictAttribute.ContainsKey(Versionnumber);
        var columnContainsVersionNumber = outputDataTable.Columns[Versionnumber] is not null;
        foreach (var entity in inputCollection.Entities) {
            var row = outputDataTable.NewRow();

            if (mappingEntityAttributeToColumn.PrimaryId is { } primaryId) {
                row[primaryId.TargetColumn] = entity.Id;
            }
            foreach (var mappingProperty in mappingEntityAttributeToColumn.ListMappingProperty) {
                object? valueTarget;
                if (entity.Attributes.TryGetValue(mappingProperty.SourceAttribute.LogicalName, out var valueSource)) {
                    valueTarget = WKUtility.ConvertFromAttributeValue(mappingProperty.SourceAttribute, valueSource);
                } else {
                    valueTarget = null;
                }
                row[mappingProperty.TargetColumn] = valueTarget;
            }

            if (metaEntityContainsVersionNumber) {
                if (System.Int64.TryParse(entity.RowVersion, out var valueRowVersion)) {
                    if (columnContainsVersionNumber) {
                        row[Versionnumber] = valueRowVersion;
                    }
                    if (result < valueRowVersion) {
                        result = valueRowVersion;
                    }
                } else if (entity.Attributes.TryGetValue(Versionnumber, out var valueAttribute)) {
                    if (columnContainsVersionNumber) {
                        row[Versionnumber] = valueAttribute;
                    }
                    try {
                        valueRowVersion = (System.Int64)(valueAttribute);
                        if (result < valueRowVersion) {
                            result = valueRowVersion;
                        }
                    } catch { }
                }
            }
            outputDataTable.Rows.Add(row);
        }

        return result;
    }
    //
    public static void CopyFromDataTable(
        DataTable inputDataTable,
        WKMetaEntity metaEntity,
        EntityCollection outputCollection,
        WKMappingEntityColumnToAttribute mappingEntityColumnToAttribute
        ) {

        var columnVersionNumber = inputDataTable.Columns[Versionnumber];
        var primaryIdColumn = (mappingEntityColumnToAttribute.PrimaryId?.SourceColumn)
                ?? inputDataTable.Columns[metaEntity.PrimaryIdAttribute];
        foreach (DataRow row in inputDataTable.Rows) {
            Entity? entity;
            if ((primaryIdColumn is not null)
                && (row[primaryIdColumn] is Guid guid)) {
                entity = new Entity(metaEntity.LogicalName, guid);
            } else {
                entity = new Entity(metaEntity.LogicalName);
            }
            if (columnVersionNumber is not null) {
                var versionnumber = row[columnVersionNumber];
                if (versionnumber is null) {
                } else if (versionnumber is Int64 versionnumberInt64) {
                    entity.RowVersion = versionnumberInt64.ToString();
                } else {
                    entity.RowVersion = versionnumber.ToString();
                }
            }
            foreach (var mappingProperty in mappingEntityColumnToAttribute.ListMappingProperty) {
                var sourceValue = row[mappingProperty.SourceColumn];
                var targetValue = WKUtility.ConvertToAttributeValue(mappingProperty.TargetAttribute, sourceValue);
                entity.Attributes[mappingProperty.TargetAttribute.LogicalName] = targetValue;
            }
            outputCollection.Entities.Add(entity);
        }
    }
    //
}
