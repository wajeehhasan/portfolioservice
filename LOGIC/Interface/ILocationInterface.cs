using DATA.Models;
using LOGIC.Model;


namespace LOGIC.Interface
{
    public interface ILocationInterface
    {
        Task<GenericResultSet<LocationLOGIC>> GetLocation(string ip_address);
    }
}
