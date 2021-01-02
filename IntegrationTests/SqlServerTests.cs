namespace IntegrationTests
{
    using System;
    using System.Data.SqlClient;

    using Dapper;
    using Xunit;


    public class SqlServerTests
    {
        private const string dockerContainerConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=1@xptoXPTO";
        public SqlServerTests()
        {
            using (var conn = new SqlConnection(dockerContainerConnnectionString))
            {
                conn.ExecuteAsync(SqlScripts.CreateTestDatabase).Wait();
            }

        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}
