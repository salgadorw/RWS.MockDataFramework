namespace DatabaseMetadataReaderService.SqlServerImplementation
{
    using System;
    using System.Collections.Generic;  
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;

    


    public class SQLServerDatabaseSchemaReader : IDatabaseSchemaRead
    {
        public async Task<DatabaseSchema> ReadAllAsync(string connectionString)
        {
            var result = new DatabaseSchema();
            using (var conn = new SqlConnection(connectionString))
            {
                result.DatabaseName = conn.Database;
                var query = await conn.QueryAsync(ReadSqlServerMetadataQueries.GetDatabaseMetadataObjects);

                foreach (var dbObject in query.GroupBy(g => g.Table_Name).Select(s => new { Name = s.Key as string, PropertiesMetadata = s.ToList() }))
                {
                    var metadataObject = new DatabaseObject() { Name = dbObject.Name };
                    
                    foreach(var dbProperty in dbObject.PropertiesMetadata)
                    {
                        var property = new DatabaseObjectProperty();


                    }
                }
            }

            return result;
        }

        public Task<DatabaseSchema> ReadByRootDatabaseObjectAsync(string objectName, string connnectionString)
        {
            throw new NotImplementedException();
        }
    }
}
