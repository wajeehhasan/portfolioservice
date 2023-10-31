using AutoMapper;
using DATA.Models;


namespace LOGIC.Model
{

    [AutoMap(typeof(LocationData))]
    public class LocationLOGIC
    {
        public string city { get; set; }
    }
}
