using AutoMapper;
using DATA.Interface;
using DATA.Models;
using LOGIC.Interface;
using LOGIC.Model;

namespace LOGIC.Implementation
{
    public class CandidateService : ICandidateInterface
    {
        //calling data layer candidate services
        private readonly ICandidateOperations _candidateOperations;
        //creating an instance of AutoMapper to Map Data Layer Cadidate to Logic Layer Candidate Model
        private readonly IMapper _mapper;
        private readonly ICommonInterface<CandidateData, CandidateLOGIC> _commonInterface;

        //making use of dependency injections so that we have access to automapper and datalayer operations in our class
        public CandidateService(ICandidateOperations candidateOperations, ICommonInterface<CandidateData, CandidateLOGIC> commonInterface)
        {
            _candidateOperations = candidateOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
            _commonInterface = commonInterface;
        }

        public GenericResultSet<CandidateLOGIC> GetCandidate()
        {
            GenericResultSet<CandidateLOGIC> response = new();
            var returnedObj = _candidateOperations.GetCandidate();
            response = _commonInterface.convertResultSet<CandidateLOGIC>(returnedObj, _mapper);
            //calling data layer operations to return desired result while also mapping it to the correct model.
            return response;
        }
    }
}
