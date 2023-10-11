using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IChatService _chatService;

        public MessageController(IChatService chatService) 
        {
            _chatService = chatService;
        }

        [HttpGet("insert_message")]
        public async Task<ActionResult> InsertMessageAsync(string groupId, long sendUserId, string message)
        {
            await _chatService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(groupId, sendUserId, message, DateTime.Now));
            
            return Ok();
        }

        [HttpGet("GetMessageLogList")]
        public async Task<ActionResult> GetMessageLogListAsync(string messageSendDate, int page, int pageSize)
        {
            var messageLogs = await _chatService.GetMessageLogListAsync(new GetMessageLogListRequest(messageSendDate, page, pageSize));
            return Ok(messageLogs);
        }
    }
}
