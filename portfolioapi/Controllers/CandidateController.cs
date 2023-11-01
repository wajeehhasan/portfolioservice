using AutoMapper;
using DATA.Models;
using LOGIC.Interface;
using LOGIC.Model;
using Microsoft.AspNetCore.Mvc;
using portfolioapi.Interface;
using portfolioapi.Models;
using System.Net.Mime;
using System.Text.Json;

namespace portfolioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase, ICandidateController
    {
        private ICandidateInterface _candidateService;
        private readonly ILogger _logger;
        private readonly ICommonInterface<CandidateLOGIC, Candidate> _commonInterface;
        private readonly IMapper _mapper;
        public CandidateController(ICandidateInterface candidateService, ICommonInterface<CandidateLOGIC, Candidate> commonInterface, ILogger<GenericResultSet<Candidate>> logger)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("portfolioapi"));
            _mapper = new Mapper(configuration);
            _candidateService = candidateService;
            _commonInterface = commonInterface;
            _logger = logger;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Candidate), 400)]
        public GenericResultSet<Candidate> candidate()
        {
            GenericResultSet<Candidate> response = new();
            var returnedObj = _candidateService.GetCandidate();
            response = _commonInterface.convertResultSet<Candidate>(returnedObj, _mapper);
            var jsonStr = JsonSerializer.Serialize(response);
            _logger.LogInformation(jsonStr);
            _logger.LogError(jsonStr);
            _logger.LogWarning(jsonStr);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "*");
            return response;

        }
    }
}
