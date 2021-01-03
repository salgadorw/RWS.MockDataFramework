namespace DatabaseMetadataReaderService.DTOs
{


using System.Collections.Generic;



    public class SchemaObjectMetadata
    {
        public string Name { get; set; }

        public List<SchemaPropertyMetadata> DatabaseObjectProperties { get; private set; } = new List<SchemaPropertyMetadata>();

        public bool HasDependency { get; set; } = false;
    }
}
