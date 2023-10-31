using DATA.Interface;
using DATA.Models;

using System.Web;

using Newtonsoft.Json;

namespace DATA.Services
{
    public class HttpOperations : IHttpOperations
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public HttpOperations(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
    
        }

        public async Task<GenericResultSet<string>> GetHttpResponse(string url, Dictionary<string, string>? queryParams=null)
        {
            var builder = new UriBuilder(url);
            GenericResultSet<string> response = new();
            var query = HttpUtility.ParseQueryString(builder.Query);
            if(queryParams!=null)
            {
                foreach (var item in queryParams)
                {
                    query.Add(item.Key, item.Value);
                }
            }

            builder.Query = query.ToString();
            var fullUrl = builder.ToString();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, fullUrl);

            var httpClient = _httpClientFactory.CreateClient();
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                response.resultSet = new StreamReader(contentStream).ReadToEnd();
            }

            else
            {
                response.status = false;
                response.message = httpResponseMessage.ReasonPhrase;
            }
            return response;
        }
        public GenericResultSet<T> GenericResponseGenerate<T>(GenericResultSet<string> returnedResponse)
        {
            GenericResultSet<T> response = new();
            if (returnedResponse.resultSet != null)
            {
                response.resultSet = JsonConvert.DeserializeObject<T>(returnedResponse.resultSet);
            }

            response.status = returnedResponse.status;
            response.message = returnedResponse.message;
            return response;
        }
    }
}
