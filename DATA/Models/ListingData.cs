
namespace DATA.Models
{
    public class ListingDetail
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public VehicleType vehicleType { get; set; }
    }

    public class ListingData
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<ListingDetail> listings { get; set; }
    }

    public class VehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }


}
