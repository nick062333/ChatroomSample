using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult> InsertMessageAsync(long sendUserId, string message)
        {
            string groupName = Guid.NewGuid().ToString();
            await _chatService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(groupName, sendUserId, message, DateTime.Now));
            
            return Ok();
        }
    }
}
