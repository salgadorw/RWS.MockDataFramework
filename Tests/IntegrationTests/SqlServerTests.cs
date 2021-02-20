namespace IntegrationTests
{
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MockMetadataReader.Foundation;
    using MockMetadataReader.SqlServerImplementation;
    using MockDataGenerator.SqlServerImplementation;
    using MockDataGenerator.Foundation;
    using Xunit;


    public class SqlServerTests
    {
        private const string dockerContainerConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=1@sqlServer";
        private const string dockerContainerDBConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=MockedDB;Persist Security Info=True;User ID=sa;Password=1@sqlServer";

        private readonly IDatabaseSchemaRead databaseSchemaReadService;
        private readonly IMockDataGeneratorService mockDataGeneratorService;

        public SqlServerTests()
        {
            using (var conn = new SqlConnection(dockerContainerConnnectionString))
            {
                conn.Open();
                conn.Execute(SqlScripts.DropAndCreateDatabase);
                conn.Execute(SqlScripts.CreateTables);
                conn.Close();
            }
            IDatabaseMetadataRepository repository = new SQLServerMetadataRepository(dockerContainerDBConnnectionString);
            databaseSchemaReadService = new SQLServerDatabaseSchemaReader(repository);
            mockDataGeneratorService = new SqlServerMockDataGeneratorService();
        }

        [Fact]
        public async Task ReadALL_ReturnSchema()
        {
            var result = await databaseSchemaReadService.ReadAllAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.DatabaseObjects.Count());
            Assert.Single(result.DatabaseObjectRelations);
        }

        [Fact]
        public async Task GenerateSQLServerDatabaseMockDataByCOnnectionString_ReturnMockedData()
        {
            var result = await mockDataGeneratorService.GenerateMockDataByConnectionString(dockerContainerDBConnnectionString);
                      
            Assert.NotEmpty(result);

            var values = result.First().propertyValues.First(f => f.PropertyName.Equals("id")).Values.Where(w => result.Last().propertyValues.Where(w => w.PropertyName.Equals("testMock")).First().Values.Contains(w));

            Assert.NotEmpty(values);
           
        }
    }
}
