using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.Model;
using portfolioapi.Models;

namespace portfolioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoDbUserActivityController : ControllerBase
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _dycontext;
        public DynamoDbUserActivityController(IDynamoDBContext context, IAmazonDynamoDB dycontext)
        {
            _context = context;
            _dycontext = dycontext;
        }
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var request = new ScanRequest
                {
                    TableName = "PortfolioUsersMessageAndFriendActivity"
                };

                var response = await _dycontext.ScanAsync(request);
                Console.WriteLine(response);
                return Ok(response);
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
                if (response.Item == null)
                {
                    return NotFound();
                }
                return Ok(response);
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
                return Ok(response.Item["friendList"].L[0].NS);
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
                return Ok(response.Item["friendRequest"].M["confirmRequestUserId"].L[0].NS);
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
                return Ok(response.Item["friendRequest"].M["sentRequestUserId"].L[0].NS);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetUserMessages/{userId}")]
        public async Task<ActionResult<DyUserActivity>> GetUserMessages(string userId)
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
                return Ok(response.Item["friendRequest"].M["sentRequestUserId"].L[0].NS);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("/{userId}")]
        //public async Task<ActionResult<DyUserActivity>> test(string userId)
        //{
        //    var tableName = "PortfolioUsersMessageAndFriendActivity";

        //    var request = new GetItemRequest
        //    {
        //        TableName = tableName,
        //        Key = new Dictionary<string, AttributeValue>
        //        {
        //            { "UserId", new AttributeValue { N = userId } }
        //        }
        //    };

        //    try
        //    {
        //        var response = await _dycontext.GetItemAsync(request);
        //        if (response.Item == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(response);
        //    }
        //    catch (AmazonDynamoDBException ex)
        //    {
        //        //Handle DynamoDB exceptions
        //        return StatusCode(500, ex.Message);
        //    }
        //}


    }
}