namespace DatabaseMetadataReaderService.DTOs
{


using System.Collections.Generic;



    public class DatabaseObject
    {
        public string Name { get; set; }

        public DatabaseObjectTypeEnum DatabaseObjectType { get; set; }

        public List<DatabaseObjectProperty> DatabaseObjectProperties { get; private set; } = new List<DatabaseObjectProperty>();

        public bool HasDependency { get; set; } = false;
    }
}
