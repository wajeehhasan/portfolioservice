using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.Model;
using portfolioapi.Models;
using Amazon.DynamoDBv2.DocumentModel;

namespace portfolioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoDbUserActivityController : ControllerBase
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _dycontext;

        //convert dynamodb Object to .net class
        private T GetObject<T>(Dictionary<string, AttributeValue> image)
        {
            var document = Document.FromAttributeMap(image);
            return _context.FromDocument<T>(document);
        }
        public DynamoDbUserActivityController(IDynamoDBContext context, IAmazonDynamoDB dycontext)
        {
            _context = context;
            _dycontext = dycontext;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<DyUserActivity> testList = new();
            try
            {
                var request = new ScanRequest
                {
                    TableName = "PortfolioUsersMessageAndFriendActivity"
                };

                var response = await _dycontext.ScanAsync(request);
                foreach(var item in response.Items)
                {
                    testList.Add(GetObject<DyUserActivity>(item));
                }
                return Ok(testList);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetusersbyID/{userId}")]
        public async Task<ActionResult<DyUserActivity>> GetusersbyID(string userId)
        {
            var tableName = "PortfolioUsersMessageAndFriendActivity";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue> 
                {
                    { "UserId", new AttributeValue { N = userId } }
                }
            };

            try
            {
                var response = await _dycontext.GetItemAsync(request);
                var test = GetObject<DyUserActivity>(response.Item);
                if (response.Item == null)
                {
                    return NotFound();
                }
                return Ok(test);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetUserFriendList/{userId}")]
        public async Task<ActionResult<DyUserActivity>> GetUserFriendList(string userId)
        {
            var tableName = "PortfolioUsersMessageAndFriendActivity";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserId", new AttributeValue { N = userId } }
                }
            };

            try
            {
                var response = await _dycontext.GetItemAsync(request);
                if (response.Item == null)
                {
                    return NotFound();
                }
                return Ok(response.Item["friendList"].NS);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetUserConfirmFriend/{userId}")]
        public async Task<ActionResult<DyUserActivity>> GetUserConfirmFriend(string userId)
        {
            var tableName = "PortfolioUsersMessageAndFriendActivity";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserId", new AttributeValue { N = userId } }
                }
            };

            try
            {
                var response = await _dycontext.GetItemAsync(request);
                if (response.Item == null)
                {
                    return NotFound();
                }
      
                return Ok(response.Item["confirmRequestUserId"].NS);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUserRequestFriend/{userId}")]
        public async Task<ActionResult<DyUserActivity>> GetUserRequestFriend(string userId)
        {
            var tableName = "PortfolioUsersMessageAndFriendActivity";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserId", new AttributeValue { N = userId } }
                }
            };

            try
            {
                var response = await _dycontext.GetItemAsync(request);
                if (response.Item == null)
                {
                    return NotFound();
                }
             
                return Ok(response.Item["sentRequestUserId"].NS);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetUserMessages/{userId}/{friendId}")]
        public async Task<ActionResult<UserMessages>> GetUserMessages(string userId, string friendId)
        {
            var tableName = "UserMessages";
      
            var request = new ScanRequest
            {
                TableName = tableName,
                FilterExpression = "friendId = :v_FriendId AND userId = :v_UserId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                {":v_FriendId", new AttributeValue {N = friendId}},
                {":v_UserId", new AttributeValue {N = userId}}
            }
            };
            try
            {
                var response = await _dycontext.ScanAsync(request);
                return Ok(response);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }
    }
}