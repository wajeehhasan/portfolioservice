using DATA.Interface;
using DATA.Models;


namespace DATA.Services
{
    public class CandidateOperations : ICandidateOperations
    {
        public GenericResultSet<CandidateData> GetCandidate()
        {

            GenericResultSet<CandidateData> response = new();
            response.resultSet = new CandidateData { name = "test", phone = "test" };
            //this is returning sample data and can be replaced by a database call
            return response; 
        }
    }
}
