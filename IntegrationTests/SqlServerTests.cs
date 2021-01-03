namespace IntegrationTests
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using DatabaseMetadataReaderService;
    using DatabaseMetadataReaderService.Foundation;
    using DatabaseMetadataReaderService.SqlServerImplementation;
    using Xunit;


    public class SqlServerTests
    {
        private const string dockerContainerConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=1@sqlServer";
        private const string dockerContainerDBConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=MockedDB;Persist Security Info=True;User ID=sa;Password=1@sqlServer";

        private readonly IDatabaseSchemaRead databaseSchemaReadService;

        public SqlServerTests()
        {
            using (var conn = new SqlConnection(dockerContainerConnnectionString))
            {
                conn.ExecuteAsync(SqlScripts.CreateTestDatabase).Wait();
            }
            IDatabaseMetadataRepository repository = new SQLServerMetadataRepository(dockerContainerDBConnnectionString);
            databaseSchemaReadService = new SQLServerDatabaseSchemaReader(repository);
        }

        [Fact]
        public async Task ReadALL_ReturnSchema()
        {
            var result = await databaseSchemaReadService.ReadAllAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.DatabaseObjects.Count());
            Assert.Single(result.DatabaseObjectRelations);
        }
    }
}
