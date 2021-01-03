namespace DatabaseMetadataReaderService.SqlServerImplementation
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DatabaseMetadataReaderService.DTOs;


    public static class MapppingExtensions
    {
        public static SchemaMetadata MappingDatabaseMetadataEntities(this IEnumerable<object> rawMetadata)
        {

            IEnumerable<dynamic> rawMetadataEntities = rawMetadata.Cast<dynamic>();
            var result = new SchemaMetadata() { Name = rawMetadataEntities.First().TABLE_CATALOG };

            foreach (var dbObject in rawMetadataEntities.GroupBy(g => g.TABLE_NAME).Select(s => new { Name = s.Key as string, PropertiesMetadata = s.ToList() }))
            {
                var metadataObject = new SchemaObjectMetadata() { Name = dbObject.Name };
             
                foreach (var dbProperty in dbObject.PropertiesMetadata.GroupBy(g => g.COLUMN_NAME).Select(S => new { ColumnName = S.Key, columnMetadata = S.ToList() }))
                {
                    var generalColumnMetadata = dbProperty.columnMetadata.First();
                    var FKName = dbProperty.columnMetadata.Where(w => w.IS_FK == 1).Select(s => (string)s.CONSTRAINT_NAME).FirstOrDefault();
                    var property = new SchemaPropertyMetadata()
                    {
                        Name = dbProperty.ColumnName,
                        IsNullable = generalColumnMetadata.IS_NULLABLE == 1,
                        PropertyType = generalColumnMetadata.DATA_TYPE,
                        DefaultValue = generalColumnMetadata.COLUMN_DEFAULT,
                        IsForeingKey = !string.IsNullOrEmpty(FKName),
                        FKName = FKName,
                        IsUnique = dbProperty.columnMetadata.Where(w => w.IS_UNIQUE == 1).Count() > 0,
                        IsKey = dbProperty.columnMetadata.Where(w => w.IS_KEY == 1).Count() > 0,
                        MaxCharacterLength = generalColumnMetadata.CHARACTER_MAXIMUM_LENGTH,
                        NumericPrecision = generalColumnMetadata.NUMERIC_PRECISION,
                        NumericScale = generalColumnMetadata.NUMERIC_SCALE

                    };

                    metadataObject.DatabaseObjectProperties.Add(property);

                    if (property.IsForeingKey)
                        metadataObject.HasDependency = true;
                }
                result.DatabaseObjects.Add(metadataObject);
            }
            return result;
        }

        public static IEnumerable<SchemaObjectDependency> MappingDatabaseMetadataRelationships(this IEnumerable<object> rawMetadata)
        {
            IEnumerable<dynamic> rawMetadataRelations = rawMetadata.Cast<dynamic>();
            foreach (var relationMetadata in rawMetadataRelations)
            {
                yield return new SchemaObjectDependency() { Name = relationMetadata.CONSTRAINT_NAME, PrimaryObjectName = relationMetadata.TABLE_NAME, PrimaryObjectPropertyName = relationMetadata.COLUMN_NAME, DependentObjectName = relationMetadata.FKTABLE, DependentObjectPropertyName = relationMetadata.FKCOLUMN };
            }

        }
    }
}
