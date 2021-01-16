﻿using MockMetadataReader.DTOs;
using MockDataGenerator.DTOs;
using MockDataGenerator.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDataGenerator.SqlServerImplementation
{
    internal class SqlserverMockDataGenerator : IMockDataGenerator
    {
        public async Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, params MockDataGeneratorOptions[] options)
        {
            var notDependentObjects = schema.DatabaseObjects.Where(w => !w.HasDependency);
            var dataFromObjectsWithNoDependency= notDependentObjects
            .Select
            (s => {
                var opt = options.Where(w => (w.ObjectName ?? "").Equals(s.Name) || w.ObjectName == null).FirstOrDefault();
                 return GenerateMockDataByMetadataSchemaAndDependenciesData(s, opt, null, schema.DatabaseObjectRelations).Result;

                 }
            ).ToList();

            return await GenerateMetadataForSchemaObject(schema.DatabaseObjects, schema.DatabaseObjectRelations, dataFromObjectsWithNoDependency, options);
           
        }

        private async Task<List<MockObjectData>> GenerateMetadataForSchemaObject(List<SchemaObjectMetadata> schemaObjects, List<SchemaObjectDependencyMedatada> dependencyMetadatas,  List<MockObjectData> MockedData, MockDataGeneratorOptions[] options)
        {
            dependencyMetadatas = dependencyMetadatas.Where(sw => MockedData.Select(s => s.Schema.Name).Contains(sw.PrimaryObjectName) && !MockedData.Select(s => s.Schema.Name).Contains(sw.DependentObjectName)).ToList();

            if (dependencyMetadatas.Count() == 0)
                return MockedData;


            var MetadataObjectToBeGenerated = schemaObjects.Where(w => dependencyMetadatas.Select(s => s.DependentObjectName).Contains(w.Name));

            var newMockedData = MetadataObjectToBeGenerated.Select(s => {
                var opt = options.Where(w => (w.ObjectName ?? "").Equals(s.Name) || w.ObjectName == null).FirstOrDefault();
                return GenerateMockDataByMetadataSchemaAndDependenciesData(s, opt, MockedData, dependencyMetadatas.Where(w=>w.DependentObjectName.Equals(s.Name)).ToList()).Result;
            }).ToList();

            MockedData.AddRange(newMockedData);

            return await GenerateMetadataForSchemaObject(schemaObjects, dependencyMetadatas, MockedData, options);
        }

        private async Task<MockObjectData> GenerateMockDataByMetadataSchemaAndDependenciesData(SchemaObjectMetadata schemaObjectMetadata, MockDataGeneratorOptions options, IEnumerable<MockObjectData> mockDataCreated, List<SchemaObjectDependencyMedatada> dependencyMetadatas)
        {
            {
                var propertyGenerator = new SqlServerMockPropertiesValueGenerator();
                var dependencies = dependencyMetadatas?.Where(w => w.DependentObjectName.Equals(schemaObjectMetadata.Name));
                var dependencyData = mockDataCreated?.SelectMany(s => s.propertyValues.Where(w=> dependencies?.Where(ww=>ww.PrimaryObjectName.Equals(s.Schema.Name) && ww.PrimaryObjectPropertyName.Equals(w.PropertyName)).Any()??false));
                return await Task.Run(()=> {
                   return new MockObjectData()
                    {
                        Schema = schemaObjectMetadata,
                        propertyValues = schemaObjectMetadata.DatabaseObjectProperties
                        .Select(
                        sp =>
                        {
                            return propertyGenerator.GenerateMockedValuesByPropertyMetadata(sp, options, dependencyData?.Where(w => w.PropertyName.Equals(sp.Name)).FirstOrDefault());
                        }
                        )
                    };
                }).ConfigureAwait(false);
            }
        }
    }
}
