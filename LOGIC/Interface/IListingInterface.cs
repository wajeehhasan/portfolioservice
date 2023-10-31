using DATA.Models;
using LOGIC.Model;


namespace LOGIC.Interface
{
    public interface IListingInterface
    {
        Task<GenericResultSet<ListingsLOGIC>> GetPricedListings(double noOfPassengers);
    }
}
