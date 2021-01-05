namespace RWS.MockGen.SqlServerImplementation
{
   
   
    using System;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Reflection;
    using System.Linq;

    using DatabaseMetadataReader.DTOs;
    using RWS.MockGen.DTOs;

    internal class SqlServerMockPropertiesValueGenerator : IMockPropertyValuesGenerator
    {

        public MockDataPropertyValues GenerateMockedValuesByPropertyMetadata(SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options)
        {
            var result = new MockDataPropertyValues();

            result.PropertyName = propertyMetadata.Name;

            result.Values.AddRange(new object[(options?.DataAmount ?? 100)]);

            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.BigInt).ToLower()))
            {

                result.PropertyType = typeof(Int64);
                GenerateMaxValueDataFromPrimitiveType(result);
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Binary).ToLower()))
            {

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Bit).ToLower()))
            {

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Char).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime).ToLower()))
            {

                result.PropertyType = typeof(DateTime);
                GenerateDateTimeNowValue(result);
            }
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
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.UniqueIdentifier).ToLower()))
            {

                result.PropertyType = typeof(Guid);
                GenerateGuidRamdomValues(result);
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
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Date).ToLower()))
            {
                result.PropertyType = typeof(SqlDateTime);
                GenerateMaxValueDataFromPrimitiveType(result);
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Time).ToLower()))
            {

                result.PropertyType = typeof(DateTime);
                GenerateDateTimeNowValue(result);

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime2).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTimeOffset).ToLower())) { }
            else
            { }
            return result;
        }

        private void GenerateMaxValueDataFromPrimitiveType(MockDataPropertyValues mockDataProperty)
        {
            var value = mockDataProperty.PropertyType.GetField("MaxValue", BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static).GetValue(new object());
            mockDataProperty.Values = mockDataProperty.Values.Select(s => value).ToList();
        }

        private void GenerateDateTimeNowValue(MockDataPropertyValues mockDataProperty)
        {
            var value = (object)DateTime.Now;
            mockDataProperty.Values = mockDataProperty.Values.Select(s => value).ToList();
        }

        private void GenerateGuidRamdomValues(MockDataPropertyValues mockDataProperty)
        {
            mockDataProperty.Values = mockDataProperty.Values.Select(s => (object)Guid.NewGuid()).ToList();
        }
    }


}
