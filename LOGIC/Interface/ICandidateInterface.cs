using DATA.Models;
using LOGIC.Model;


namespace LOGIC.Interface
{
    public interface ICandidateInterface
    {
        GenericResultSet<CandidateLOGIC> GetCandidate();
    }
}
