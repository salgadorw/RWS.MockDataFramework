namespace MockDataGenerator.SqlServerImplementation
{
   
   
    using System;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Reflection;
    using System.Linq;

    using MockMetadataReader.DTOs;
    using MockDataGenerator.DTOs;
    using System.Text;

    internal class SqlServerMockPropertiesValueGenerator : IMockPropertyValuesGenerator
    {

        public MockDataPropertyValues GenerateMockedValuesByPropertyMetadata(SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options, MockDataPropertyValues dependecyValues=null)
        {
            var result = new MockDataPropertyValues();

            result.PropertyName = propertyMetadata.Name;

            result.Values.AddRange(new object[(options?.DataAmount ?? 100)]);

            if (dependecyValues != null)
            {
                result.PropertyType = dependecyValues.PropertyType;
               AddRamdomValueForMockDataProperties(result, r => dependecyValues.Values[r.Next(dependecyValues.Values.Count)]);
            }
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.BigInt).ToLower()))
            {

                result.PropertyType = typeof(Int64);
                GenerateMaxValueDataFromPrimitiveType(result);
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Binary).ToLower()))
            {
                result.PropertyType = typeof(SqlBinary);
                AddRamdomValueForMockDataProperties(result, r =>
                {
                    var rdn = new byte[new Random().Next(8000)];
                    r.NextBytes(rdn);
                    return new SqlBinary(rdn);
                });
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Bit).ToLower()))
            {
                result.PropertyType = typeof(bool);
                AddRamdomValueForMockDataProperties(result, r => (object)(r.Next(2) == 1 ? true : false));
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Char).ToLower())) {

                result.PropertyType = typeof(SqlChars);
                AddRamdomValueForMockDataProperties(result, r =>
                {

                    int charsize = propertyMetadata.MaxCharacterLength.GetValueOrDefault(r.Next(8000));
                    var charscreated = new char[charsize];


                    return new SqlChars(charscreated.ToList().Select(s => Convert.ToChar(r.Next(256))).ToArray());
                });

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime).ToLower()))
            {

                result.PropertyType = typeof(DateTime);
                AddRamdomValueForMockDataProperties(result, r => DateTime.Now.AddMinutes(r.Next(1444)));
            }        
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Decimal).ToLower()) || propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Money).ToLower())) {

                result.PropertyType = typeof(SqlDecimal);
                AddRamdomValueForMockDataProperties(result, r => new SqlDecimal(decimal.Round((new decimal(r.NextDouble())*decimal.MaxValue)/propertyMetadata.NumericPrecision.GetValueOrDefault(int.MaxValue),propertyMetadata.NumericScale.GetValueOrDefault(0))));
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Float).ToLower()) || propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Real).ToLower()) || propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallMoney).ToLower())) {

                result.PropertyType = typeof(SqlDouble);
                AddRamdomValueForMockDataProperties(result, r => new SqlDouble(r.NextDouble()*float.MaxValue));

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Image).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Int).ToLower())) {
                result.PropertyType = typeof(SqlInt32);
                AddRamdomValueForMockDataProperties(result, r => r.Next());

            }
            else
           
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NChar).ToLower()) || propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NVarChar).ToLower())) {
                result.PropertyType = typeof(SqlChars);
                AddRamdomValueForMockDataProperties(result, r =>
                {

                    int charsize = propertyMetadata.MaxCharacterLength.GetValueOrDefault(r.Next(8000));
                    var charscreated = new char[charsize];


                    return new SqlChars(charscreated.ToList().Select(s => Convert.ToChar(r.Next(256))).ToArray());
                });
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.NText).ToLower())) { }
            else
            
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.UniqueIdentifier).ToLower()))
            {

                result.PropertyType = typeof(Guid);
                GenerateGuidRamdomValues(result);
            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallDateTime).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.SmallInt).ToLower())) {
                result.PropertyType = typeof(SqlInt16);
                AddRamdomValueForMockDataProperties(result, r => r.Next(short.MaxValue));
            }
            else
           
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Text).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.Timestamp).ToLower())) { }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.TinyInt).ToLower())) {
                result.PropertyType = typeof(SqlByte);
                AddRamdomValueForMockDataProperties(result, r => r.Next(Byte.MaxValue));
            }
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

                result.PropertyType = typeof(TimeSpan);
                AddRamdomValueForMockDataProperties(result, r => DateTime.Now.TimeOfDay);

            }
            else
            if (propertyMetadata.PropertyType.Equals(nameof(SqlDbType.DateTime2).ToLower())) {
                result.PropertyType = typeof(DateTime);
                AddRamdomValueForMockDataProperties(result, r=> DateTime.Now.AddMinutes(r.Next(1444)));
            }
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
             

        private void GenerateGuidRamdomValues(MockDataPropertyValues mockDataProperty)
        {
            mockDataProperty.Values = mockDataProperty.Values.Select(s => (object)Guid.NewGuid()).ToList();
        }

        private void AddRamdomValueForMockDataProperties(MockDataPropertyValues mockDataProperty, Func<Random, Object> func)
        {

            mockDataProperty.Values = mockDataProperty.Values.Select(s => {

                return func(new Random());
            }).ToList();
        }
    }


}
