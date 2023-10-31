using AutoMapper;
using LOGIC.Model;

namespace portfolioapi.Models
{
    [AutoMap(typeof(CandidateLOGIC))]
    public class Candidate
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
