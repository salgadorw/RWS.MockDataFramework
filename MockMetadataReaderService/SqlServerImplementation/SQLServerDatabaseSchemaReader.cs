﻿namespace MockMetadataReader.SqlServerImplementation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MockMetadataReader.DTOs;
    using MockMetadataReader.Foundation;


    public class SQLServerDatabaseSchemaReader : IDatabaseSchemaRead
    {
        private readonly IDatabaseMetadataRepository repository;

        public SQLServerDatabaseSchemaReader(IDatabaseMetadataRepository repository)
        {
            this.repository = repository;
        }
        public async Task<SchemaMetadata> ReadAllAsync()
        {
            var metadataObjects = await repository.GetDatadaseMetadataObjects();

            var result = metadataObjects.Cast<Object>().MappingDatabaseMetadataEntities();
            var relationships = await repository.GetDatadaseMetadataRelationships();
            result.DatabaseObjectRelations.AddRange(relationships.Cast<Object>().MappingDatabaseMetadataRelationships());        

            return result;
        }

        public Task<SchemaMetadata> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects)
        {
            throw new NotImplementedException();
        }
    }
}
