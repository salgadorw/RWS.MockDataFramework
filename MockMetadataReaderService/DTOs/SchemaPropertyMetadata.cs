namespace MockMetadataReader.DTOs
{
    public class SchemaPropertyMetadata
    {

        public string Name { get; set; }

        public string PropertyType { get; set; }

        public bool IsNullable { get; set; }

        public bool IsUnique { get; set; }

        public bool IsKey { get; set; }

        public bool IsForeingKey {get;set;}  

        public string FKName { get; set; }

        public string DefaultValue { get; set; }

        public int? MaxCharacterLength { get; set; }

        public int? NumericPrecision { get; set; }

        public int? NumericScale { get; set; }
      
    }
}
