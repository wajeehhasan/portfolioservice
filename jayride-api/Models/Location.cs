using AutoMapper;
using LOGIC.Model;

namespace portfolioapi.Models
{
    [AutoMap(typeof(LocationLOGIC))]
    public class Location
    {
        public string city { get; set; }
    }
}
