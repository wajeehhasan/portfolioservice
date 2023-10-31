using AutoMapper;
using DATA.Models;

namespace LOGIC.Model
{
    [AutoMap(typeof(CandidateData))]
    public class CandidateLOGIC
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
