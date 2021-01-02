namespace DatabaseMetadataReaderService
{
    public class DatabaseObjectRelation
    {
        public string Name { get; set; }

        public string PrimaryObjectName { get; set; }

        public string PrimaryObjectPropertyNanme { get; set; }

        public string DependentObjectName { get; set; }

        public string DependentObjectPropertyName { get; set; }
    }
}