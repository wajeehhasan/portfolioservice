using AutoMapper;
using LOGIC.Model;

namespace portfolioapi.Models
{
    [AutoMap(typeof(DyUserMessagesBLL))]
    public class DyUserDetailsCont
    {
        public string UserId { get; set; }
        public List<string> confirmRequestUserId { get; set; }
        public List<string> friendList { get; set; }
        public List<string> sentRequestUserId { get; set; }
        public string userName { get; set; }
    }
}
