using AutoMapper;
using LOGIC.Model;

namespace portfolioapi.Models
{
    [AutoMap(typeof(DyUserDetailsBLL))]
    public class DyUserMessagesCont
    {
        public int MessageId { get; set; }
        public long absoluteTime { get; set; }
        public int friendId { get; set; }
        public string messageBody { get; set; }
        public string messageDate { get; set; }
        public string messageDay { get; set; }
        public string messageTime { get; set; }
        public string userEmail { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
