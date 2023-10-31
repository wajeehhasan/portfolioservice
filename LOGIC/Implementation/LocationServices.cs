using LOGIC.Model;
using LOGIC.Interface;
using DATA.Models;
using DATA.Interface;
using AutoMapper;


namespace LOGIC.Implementation
{
    public class LocationServices : ILocationInterface
    {
        private readonly ILocationOperations _locationOperations;
        private readonly ICommonInterface<LocationData,LocationLOGIC> _commonInterface;
        private readonly IMapper _mapper;
        public LocationServices(ILocationOperations locationOperations, ICommonInterface<LocationData, LocationLOGIC> commonInterface)
        {
            _locationOperations = locationOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
            _commonInterface = commonInterface;
        }

        public async Task<GenericResultSet<LocationLOGIC>> GetLocation(string ip_address)
        {
            GenericResultSet<LocationLOGIC> responseDTO = new();
            var ipDetails = await _locationOperations.GetIpDetailsAsync(ip_address);
            responseDTO = _commonInterface.convertResultSet<LocationLOGIC>(ipDetails, _mapper);
            return responseDTO;
        }
    }
}
