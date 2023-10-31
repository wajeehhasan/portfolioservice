using DATA.Interface;
using DATA.Models;
using DATA.Services;
using portfolioapi.Interface;
using portfolioapi.Models;
using Xunit;

namespace jayride_api.Test
{
    public class UnitTest2
    {
        ICandidateOperations _candidateService;
        ICandidateController _candidateController;
        public UnitTest2()
        {
            _candidateService = new CandidateOperations();
            _candidateController = new CandidateControllerMock();
        }


        [Fact]
        public void GetCandidate_Controller_Test_Successful()
        {
            //Act
            var Result = _candidateController.candidate();

            //Assert
            Assert.NotNull(Result.resultSet);
            Assert.IsType<GenericResultSet<Candidate>>(Result);
            Assert.IsType<Candidate>(Result.resultSet);
            Assert.Equal("test", Result.resultSet.name);
            Assert.Equal("test", Result.resultSet.phone);
        }

    }
}