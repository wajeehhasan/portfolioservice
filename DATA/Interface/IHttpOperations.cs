using DATA.Models;


namespace DATA.Interface
{
    public interface IHttpOperations
    {
        Task<GenericResultSet<string>> GetHttpResponse(string url, Dictionary<string, string>? queryParams=null);
        GenericResultSet<T> GenericResponseGenerate<T>(GenericResultSet<string> returnedResponse);
    }
}
