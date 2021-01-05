namespace RWS.MockGen.Foundation
{
    using global::RWS.MockGen.DTOs;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMockDataGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>DatabaseInsertDataScriptGenerated</returns>
        Task<string> GenerateMockDataByConnectionString(string connectionString, params MockDataGeneratorOptions[] options);
        

    }
}
