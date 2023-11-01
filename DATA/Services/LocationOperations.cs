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

                var url = "http://api.ipstack.com/" + ip_address; 
                Console.WriteLine(url);
                var queryParams = new Dictionary<string, string>(){
                {"access_key", "e4004debe47a8006abb8fa6b6858f97c"}
            };

                Console.WriteLine(_config.GetSection("IpStackUrl").Value);
                var returnedObj = await _httpOperations.GetHttpResponse(url, queryParams);

                response = _httpOperations.GenericResponseGenerate<LocationData>(returnedObj);
                Console.WriteLine("Data/LocationOperation Response: " + response.resultSet + ", " + response.message);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
