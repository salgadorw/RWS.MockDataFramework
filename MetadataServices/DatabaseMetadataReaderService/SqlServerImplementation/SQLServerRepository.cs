using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


using DatabaseMetadataReaderService.Foundation;

using Dapper;

namespace DatabaseMetadataReaderService.SqlServerImplementation
{
    public class SQLServerMetadataRepository : IDatabaseMetadataRepository, IDisposable
    {
        
        private readonly SqlConnection conn;
        public SQLServerMetadataRepository(string connectionString)
        {
            
            conn = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }

        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataObjects()
        {
        
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataObjects, $"{conn.Database}"));
        }

        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataObjectsByRootObjects(params string[] rootObjects)
        {
           
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataObjects, $"{conn.Database}"), rootObjects);
        }

        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataRelationships()
        {
           
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataRelationships, $"{conn.Database}"));
        }


    }
}
