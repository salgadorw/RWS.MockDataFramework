﻿namespace DatabaseMetadataReaderService
{


using System.Collections.Generic;



    public class DatabaseObject
    {
        public string Name { get; set; }

        public DatabaseObjectTypeEnum DatabaseObjectType { get; set; }

        public List<DatabaseObjectProperty> DatabaseObjectProperties { get; set; }
    }
}
