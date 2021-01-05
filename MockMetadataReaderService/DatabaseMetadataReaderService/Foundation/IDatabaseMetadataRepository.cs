namespace DatabaseMetadataReader.Foundation
{ 
    public interface IDatabaseMetadataRepository
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<dynamic>> GetDatadaseMetadataObjects();
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<dynamic>> GetDatadaseMetadataObjectsByRootObjects(params string[] rootObjects);
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<dynamic>> GetDatadaseMetadataRelationships();
    }
}