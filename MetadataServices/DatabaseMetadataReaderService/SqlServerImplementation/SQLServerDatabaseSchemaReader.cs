namespace DatabaseMetadataReaderService.SqlServerImplementation
{
    using System;
    using System.Collections.Generic;  
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using DatabaseMetadataReaderService.DTOs;
    using DatabaseMetadataReaderService.Foundation;


    public class SQLServerDatabaseSchemaReader : IDatabaseSchemaRead
    {
        private readonly IDatabaseMetadataRepository repository;

        public SQLServerDatabaseSchemaReader(IDatabaseMetadataRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DatabaseSchema> ReadAllAsync()
        {
            var metadataObjects = await repository.GetDatadaseMetadataObjects();

            var result = metadataObjects.Cast<Object>().MappingDatabaseMetadataEntities();

            return result;
        }

        public Task<DatabaseSchema> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects)
        {
            throw new NotImplementedException();
        }
    }
}
