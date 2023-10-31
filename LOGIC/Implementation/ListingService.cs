using AutoMapper;
using DATA.Interface;
using DATA.Models;
using LOGIC.Interface;
using LOGIC.Model;


namespace LOGIC.Implementation
{
    public class ListingService : IListingInterface
    {
        private readonly IListingOperations _listingOperations;
        private readonly IMapper _mapper;
        private readonly ICommonInterface<ListingData, ListingsLOGIC> _commonInterface;
        public ListingService(IListingOperations listingOperations, ICommonInterface<ListingData, ListingsLOGIC> commonInterface)
        {
            _listingOperations = listingOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
            _commonInterface = commonInterface;
        }
        public async Task<GenericResultSet<ListingsLOGIC>> GetPricedListings(double noOfPassengers)
        {
            GenericResultSet<ListingsLOGIC> response = new();
            //get all listings from API
            var allListings = await _listingOperations.GetAllListings();


            //filtering listingdetails where no of passengers are greater
            allListings.resultSet.listings = allListings.resultSet.listings.Where(item => item.vehicleType.maxPassengers>=noOfPassengers).ToList();

            //maping to logic layer listing model with added property of "totalPrice" so that it can be ordered.
            response = _commonInterface.convertResultSet<ListingsLOGIC>(allListings, _mapper);
            response.resultSet.listings = response.resultSet.listings
                .Select(item => { item.totalPrice = item.pricePerPassenger * noOfPassengers; return item; }) //calculating total price
                .OrderBy(item=> item.totalPrice) //ordering by totalPrice
                .ToList();

            return response;
        }
    }
}
