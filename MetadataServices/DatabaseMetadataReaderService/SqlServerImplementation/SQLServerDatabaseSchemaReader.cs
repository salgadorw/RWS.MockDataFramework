namespace DatabaseMetadataReaderService
{
    using System;
    using System.Collections.Generic;  
    using System.Data.SqlClient;
    using System.Text;

  
    using Dapper;

    


    public class SQLServerDatabaseSchemaReader : IDatabaseSchemaRead
    {
        public DatabaseSchema ReadAll(string connectionString)
        {
            throw new NotImplementedException();
        }

        public DatabaseSchema ReadByRootDatabaseObject(string objectName, string connnectionString)
        {
            throw new NotImplementedException();
        }
    }
}
