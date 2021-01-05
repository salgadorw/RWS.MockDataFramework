namespace DatabaseMetadataReader.DTOs
{

    using System.Collections.Generic;



    public class SchemaMetadata
    {
        public string Name { get; set; }

        public List<string> RootObjects { get; private set; } = new List<string>();

        public List<SchemaObjectMetadata> DatabaseObjects { get; private set; } = new List<SchemaObjectMetadata>();

        public List<SchemaObjectDependencyMedatada> DatabaseObjectRelations { get; private set; } = new List<SchemaObjectDependencyMedatada>();
    }
}
