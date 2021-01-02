namespace DatabaseMetadataReaderService.DTOs
{

    using System.Collections.Generic;



    public class DatabaseSchema
    {
        public string DatabaseName { get; set; }

        public List<string> RootObjects { get; private set; } = new List<string>();

        public List<DatabaseObject> DatabaseObjects { get; private set; } = new List<DatabaseObject>();

        public List<DatabaseObjectRelation> DatabaseObjectRelations { get; private set; } = new List<DatabaseObjectRelation>();
    }
}
