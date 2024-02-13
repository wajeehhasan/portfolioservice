using Amazon.DynamoDBv2.DataModel;

namespace portfolioapi.Models
{
    public class MessageDetails
    {
        public string absoluteTime { get; set; }
        public string messageBody { get; set; }
        public string messageDate { get; set; }
        public string messageTime { get; set; }
    }

    public class Message
    {
        public string friendId { get; set; }
        public List<MessageDetails> messageDetails { get; set; }
    }

    public class FriendRequest
    {
        public List<Message> confirmRequestUserId { get; set; }
        public List<Message> sentRequestUserId { get; set; }
    }

    [DynamoDBTable("PortfolioUsersMessageAndFriendActivity")]
    public class DyUserActivity
    {
        public string UserId { get; set; }
        public List<string> friendList { get; set; }
        public FriendRequest friendRequest { get; set; }
        public List<Message> Messages { get; set; }
        public string userName { get; set; }
    }
}
