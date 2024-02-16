using Amazon.DynamoDBv2.DataModel;

namespace portfolioapi.Models
{
    [DynamoDBTable("UserMessages")]
    public class UserMessages
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


    [DynamoDBTable("PortfolioUsersMessageAndFriendActivity")]
    public class DyUserActivity
    {
        public string UserId { get; set; }
        public List<string> confirmRequestUserId { get; set; }
        public List<string> friendList { get; set; }
        public List<string> sentRequestUserId { get; set; }
        public string userName { get; set; }
    }
}
