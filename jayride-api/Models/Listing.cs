using AutoMapper;
using LOGIC.Model;

namespace portfolioapi.Models
{
    [AutoMap(typeof(LOGIC.Model.ListingDetail))]
    public class ListingDetail
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public double totalPrice { get; set; }
        public VehicleType vehicleType { get; set; }
    }

    [AutoMap(typeof(ListingsLOGIC))]
    public class Listing
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<ListingDetail> listings { get; set; }
    }
    [AutoMap(typeof(LOGIC.Model.VehicleType))]
    public class VehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }
}
