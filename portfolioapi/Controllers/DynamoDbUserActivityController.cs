using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.Model;
using portfolioapi.Models;
using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
using DATA.Models;
using LOGIC.Interface;
using LOGIC.Model;
using System.Net;

namespace portfolioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoDbUserActivityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommonInterface<DyUserDetailsBLL, DyUserDetailsCont> _userDetailsConvert;
        private readonly ICommonInterface<DyUserMessagesBLL, DyUserMessagesCont> _userMessageConvert;
        private readonly ICommonInterface<List<DyUserDetailsBLL>, List<DyUserDetailsCont>> _userDetailsListConvert;
        private readonly ICommonInterface<List<DyUserMessagesBLL>, List<DyUserMessagesCont>> _userMessageListConvert;
        private readonly IDynamoUserInterface _dynamodbUserInterface;

        public DynamoDbUserActivityController(

             IMapper mapper,
             IDynamoUserInterface dynamodbUserInterface,
             ICommonInterface<DyUserDetailsBLL, DyUserDetailsCont> userDetailsConvert,
             ICommonInterface<DyUserMessagesBLL, DyUserMessagesCont> userMessageConvert,
             ICommonInterface<List<DyUserDetailsBLL>, List<DyUserDetailsCont>> userDetailsListConvert,
             ICommonInterface<List<DyUserMessagesBLL>, List<DyUserMessagesCont>> userMessageListConvert
            )
        {
            _userDetailsConvert = userDetailsConvert;
            _userMessageConvert = userMessageConvert;
            _userDetailsListConvert = userDetailsListConvert;
            _userMessageListConvert = userMessageListConvert;
            _dynamodbUserInterface = dynamodbUserInterface;

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("portfolioapi"));
            _mapper = new Mapper(configuration);
        
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            GenericResultSet<List<DyUserDetailsCont>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetAllUsers();
                response = _userDetailsListConvert.convertResultSet<List<DyUserDetailsCont>>(returnedObj, _mapper);
                return Ok(response);
            }
            catch (AmazonDynamoDBException ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }
        [HttpGet("GetusersbyID/{userId}")]
        public async Task<IActionResult> GetusersbyID(string userId)
        {
            GenericResultSet<DyUserDetailsCont> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserbyId(userId);
                response = _userDetailsConvert.convertResultSet<DyUserDetailsCont>(returnedObj, _mapper);
                return Ok(response);
            }
            catch (AmazonDynamoDBException ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }
        [HttpGet("GetUserFriendList/{userId}")]
        public async Task<IActionResult> GetUserFriendList(string userId)
        {
            GenericResultSet<List<string>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserFriendList(userId);
                return Ok(returnedObj);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }
        [HttpGet("GetUserConfirmFriend/{userId}")]
        public async Task<IActionResult> GetUserConfirmFriend(string userId)
        {
            GenericResultSet<List<string>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserConfirmFriend(userId);
                return Ok(returnedObj);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }

        [HttpGet("GetUserRequestFriend/{userId}")]
        public async Task<IActionResult> GetUserRequestFriend(string userId)
        {
            GenericResultSet<List<string>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserRequestFriend(userId);
                return Ok(returnedObj);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }


        [HttpGet("GetUserMessagesWithFriend/{userId}/{friendId}")]
        public async Task<IActionResult> GetUserMessagesWithFriend(string userId, string friendId)
        {
            GenericResultSet<List<DyUserMessagesCont>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserMessagesWithfriend(userId, friendId);
                response = _userMessageListConvert.convertResultSet<List<DyUserMessagesCont>>(returnedObj, _mapper);
                return Ok(response);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }

        [HttpGet("GetUserMessages/{userId}")]
        public async Task<IActionResult> GetUserMessages(string userId)
        {
            GenericResultSet<List<DyUserMessagesCont>> response = new();
            try
            {
                var returnedObj = await _dynamodbUserInterface.GetUserMessages(userId);
                response = _userMessageListConvert.convertResultSet<List<DyUserMessagesCont>>(returnedObj, _mapper);
                return Ok(response);
            }
            catch (AmazonDynamoDBException ex)
            {
                //Handle DynamoDB exceptions
                response.status = false;
                response.message = ex.Message;
                response.resultSet = null;
                //Handle DynamoDB exceptions
                return StatusCode(((int)ex.StatusCode), response);
            }
        }
    }
}