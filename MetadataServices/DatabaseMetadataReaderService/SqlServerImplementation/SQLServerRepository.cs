using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


using DatabaseMetadataReaderService.Foundation;

using Dapper;

namespace DatabaseMetadataReaderService.SqlServerImplementation
{
    public class SQLServerMetadataRepository : IDatabaseMetadataRepository
    {
        private readonly string connectionString;
        public SQLServerMetadataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataObjects()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataObjects, $"{conn.Database}"));
        }

        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataObjectsByRootObjects(params string[] rootObjects)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataObjects, $"{conn.Database}"), rootObjects);
        }

        public async Task<IEnumerable<dynamic>> GetDatadaseMetadataRelationships(string connectionString)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync(string.Format(ReadSqlServerMetadataQueries.GetDatabaseMetadataRelationships, $"{conn.Database}"));
        }
    }
}
