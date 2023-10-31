
using DATA.Models;
using portfolioapi.Interface;
using portfolioapi.Models;

namespace jayride_api.Test
{
    public class CandidateControllerMock : ICandidateController
    {
        public GenericResultSet<Candidate> candidate()
        {
            return new GenericResultSet<Candidate> ()
            {
                resultSet = new Candidate () { name = "test", phone = "test"}
            };
        }
    }
}
