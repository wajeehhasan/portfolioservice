using DATA.Models;
using portfolioapi.Models;

namespace portfolioapi.Interface
{
    public interface ICandidateController
    {
        GenericResultSet<Candidate> candidate();
    }
}
