namespace DatabaseMetadataReaderService
{

    using System.Collections.Generic;



    public class DatabaseSchema
    {
        public string DatabaseName { get; set; }

        public List<DatabaseObject> RootObjects { get; set; }

        public List<DatabaseObject> DatabaseObjects { get; set; }

        public List<DatabaseObjectRelation> DatabaseObjectRelations { get; set; }
    }
}
