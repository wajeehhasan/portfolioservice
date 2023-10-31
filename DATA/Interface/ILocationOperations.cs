using DATA.Models;

namespace DATA.Interface
{
    public interface ILocationOperations
    {
        Task<GenericResultSet<LocationData>> GetIpDetailsAsync(string ip_address);
    }
}
