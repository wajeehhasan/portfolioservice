using DATA.Interface;
using DATA.Models;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace DATA.Services
{
    public class LocationOperations : ILocationOperations
    {
        private readonly IHttpOperations _httpOperations;
        private readonly IConfiguration _config;

        public LocationOperations(IConfiguration config, IHttpOperations httpOperations)
        {
            _config = config;
            _httpOperations = httpOperations;
        }
        public async Task<GenericResultSet<LocationData>> GetIpDetailsAsync(string ip_address)
        {
            try
            {
                GenericResultSet<LocationData> response = new();
                var ipStackUrl = Environment.GetEnvironmentVariable("IpStackUrl");
                var ipStackKey = Environment.GetEnvironmentVariable("IpstackAccessKey");
                var url = ipStackUrl + ip_address; 
                var queryParams = new Dictionary<string, string>(){
                {"access_key", ipStackKey}
            };

       
                var returnedObj = await _httpOperations.GetHttpResponse(url, queryParams);

                response = _httpOperations.GenericResponseGenerate<LocationData>(returnedObj);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
