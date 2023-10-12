using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModels.Message;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : BaseController
    {
        private readonly IChatService _chatService;

        public MessageController(IChatService chatService) 
        {
            _chatService = chatService;
        }

        [HttpGet("insert_message")]
        public async Task<ActionResult> InsertMessageAsync(Guid groupId, long sendUserId, string message)
        {
            await _chatService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(groupId, sendUserId, message, DateTime.Now));
            
            return Ok();
        }

        [HttpPost("get_message_log_list")]
        public async Task<ActionResult> GetMessageLogListAsync(GetMessageLogListViewModel getMessageLogListViewModel)
        {
            var messageLogs = await _chatService.GetMessageLogListAsync(new GetMessageLogListRequest(
                getMessageLogListViewModel.GroupId, 
                getMessageLogListViewModel.Page, 
                getMessageLogListViewModel.PageSize));

            return Ok(messageLogs);
        }
    }
}
