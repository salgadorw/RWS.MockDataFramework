namespace DatabaseMetadataReaderService
{
    
    public interface IDatabaseSchemaRead
    {
        DatabaseSchema ReadAll(string connectionString);

        DatabaseSchema ReadByRootDatabaseObject(string objectName, string connnectionString);

    }
}
