namespace DatabaseMetadataReaderService.DTOs
{
    public class SchemaObjectDependencyMedatada
    {
        public string Name { get; set; }

        public string PrimaryObjectName { get; set; }

        public string PrimaryObjectPropertyName { get; set; }

        public string DependentObjectName { get; set; }

        public string DependentObjectPropertyName { get; set; }
    }
}