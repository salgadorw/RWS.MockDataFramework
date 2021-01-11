namespace MockDataGenerator.Foundation
{
    using MockDataGenerator.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMockDataGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>DatabaseInsertDataScriptGenerated</returns>
        Task<IEnumerable<MockObjectData>> GenerateMockDataByConnectionString(string connectionString, params MockDataGeneratorOptions[] options);
        

    }
}
