namespace GenerateDatabaseMockDataService.Foundation
{
    using GenerateMockDataService.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGenerateMockDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>DatabaseInsertDataScriptGenerated</returns>
        Task<string> GenerateSQLServerDatabaseMockDataByCOnnectionString(string connectionString, params MockDataGeneratorOptions[] options);
        

    }
}
