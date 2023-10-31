using DATA.Models;


namespace DATA.Interface
{
    public interface ICandidateOperations
    {
        GenericResultSet<CandidateData> GetCandidate();
    }
}
