using DATA.Interface;
using DATA.Models;
using DATA.Services;
using jayride_api.Models;
using portfolioapi.Interface;
using Xunit;

namespace jayride_api.Test
{
    public class UnitTest1
    {
        ICandidateOperations _candidateService;
        ICandidateController _candidateController;
        public UnitTest1()
        {
            _candidateService = new CandidateOperations();
            _candidateController = new CandidateControllerMock();
        }

        [Fact]
        public void GetCandidate_Data_Test_Successful()
        {
            //Act
            var Result = _candidateService.GetCandidate();

            //Assert
            Assert.NotNull(Result.resultSet);
            Assert.IsType<GenericResultSet<CandidateData>>(Result);
            Assert.IsType<CandidateData>(Result.resultSet);
            Assert.Equal("test", Result.resultSet.name);
            Assert.Equal("test", Result.resultSet.phone);
        }

    }
}