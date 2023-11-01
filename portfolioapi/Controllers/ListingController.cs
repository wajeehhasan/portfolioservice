using AutoMapper;
using DATA.Models;
using LOGIC.Interface;
using LOGIC.Model;
using Microsoft.AspNetCore.Mvc;
using portfolioapi.Models;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace portfolioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly Mapper _mapper;
        private readonly IListingInterface _listingInterface;
        private readonly ICommonInterface<ListingsLOGIC, Listing> _commonInterface;
        public ListingController(IListingInterface listingInterface, ICommonInterface<ListingsLOGIC, Listing> commonInterface)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("portfolioapi"));
            _mapper = new Mapper(configuration);
            _listingInterface = listingInterface;
            _commonInterface = commonInterface;
        }

        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GenericResultSet<Listing>> Listings(double noOfPassengers)
        {
            GenericResultSet<Listing> response = new();
            try
            {
                
                var returnedOBj = await _listingInterface.GetPricedListings(noOfPassengers);
                response = _commonInterface.convertResultSet<Listing>(returnedOBj, _mapper);

                return response;
            }
            catch (Exception ex)
            {
                response.message =  ex.Message;

                return response;
            }

        }
    }
}
