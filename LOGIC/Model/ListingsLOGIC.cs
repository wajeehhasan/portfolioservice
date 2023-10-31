using AutoMapper;
using DATA.Models;


namespace LOGIC.Model
{
    [AutoMap(typeof(DATA.Models.ListingDetail))]
    public class ListingDetail
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public double totalPrice { get; set; }
        public VehicleType vehicleType { get; set; }
    }

    [AutoMap(typeof(ListingData))]
    public class ListingsLOGIC
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<ListingDetail> listings { get; set; }
    }

    [AutoMap(typeof(DATA.Models.VehicleType))]
    public class VehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }
}
