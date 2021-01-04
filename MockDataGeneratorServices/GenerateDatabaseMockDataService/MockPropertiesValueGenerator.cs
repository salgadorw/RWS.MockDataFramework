namespace GenerateMockDataService
{
    using System.Collections.Generic;

    using DatabaseMetadataReaderService.DTOs;
    using global::GenerateMockDataService.DTOs;
    using System;
    using System.Data;
    using System.Reflection;
    using System.Linq;

    internal static class MockPropertiesValueGeneratorExtensions
    {
        public static MockDataPropertyValues GenerateSqlServerMockedFieldValues(this SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options)
        {

            var result = new MockDataPropertyValues();

            result.PropertyName = propertyMetadata.Name;
                        
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.BigInt).ToLower())) {

                result.PropertyType = typeof(Int64);
                result.Values.AddRange(result.PropertyType.GenerateMaxValueDataFromPrimitiveType(100));
            
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Binary).ToLower())) { 
            
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Bit).ToLower())) { 
            
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Char).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Decimal).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Float).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Image).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Int).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Money).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NChar).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NText).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NVarChar).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Real).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.UniqueIdentifier).ToLower())) {

                if (!string.IsNullOrEmpty(propertyMetadata.DefaultValue))
                    return null;
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallDateTime).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallInt).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallMoney).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Text).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Timestamp).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.TinyInt).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.VarBinary).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.VarChar).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Variant).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Xml).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Udt).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Structured).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Date).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Time).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime2).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTimeOffset).ToLower())) { }
            else
            { }        
            return null;
        }

        public static List<Object> GenerateMaxValueDataFromPrimitiveType(this Type type, int amount)
        {

            var result = new object[amount];
            var value = type.GetField("MaxValue", BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static).GetValue(new object());
            foreach (var item in result.Select((value, i) => new { i, value }))
               
            {
                result[item.i] = value;
                
            }
            return result.ToList();
        }
    }
        
        
}
