namespace IntegrationTests
{
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using DatabaseMetadataReaderService;
    using DatabaseMetadataReaderService.SqlServerImplementation;
    using Xunit;


    public class SqlServerTests
    {
        private const string dockerContainerConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=1@xptoXPTO";
        private const string dockerContainerDBConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=MockedDB;Persist Security Info=True;User ID=sa;Password=1@xptoXPTO";

        private readonly IDatabaseSchemaRead databaseSchemaReadService;

        public SqlServerTests()
        {
            using (var conn = new SqlConnection(dockerContainerConnnectionString))
            {
                conn.ExecuteAsync(SqlScripts.CreateTestDatabase).Wait();
            }
            databaseSchemaReadService = new SQLServerDatabaseSchemaReader();
        }

        [Fact]
        public async Task ReadALL_ReturnSchema()
        {
            var result = await databaseSchemaReadService.ReadAllAsync(dockerContainerDBConnnectionString);
            Assert.NotNull(result);
        }
    }
}
