using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModels.Message;

namespace webapi.Controllers
{
    /// <summary>
    /// 聊天室訊息
    /// </summary>
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService) 
        {
            _messageService = messageService;
        }

        [HttpGet("insert_message")]
        public async Task<ActionResult> InsertMessageAsync(Guid groupId, long sendUserId, string message)
        {
            await _messageService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(groupId, sendUserId, message, DateTime.Now));
            
            return Ok();
        }

        [HttpGet("get_message_log_list_total_count")]
        public async Task<ActionResult> GetMessageLogTotalCountAsync(Guid groupId)
        {
            var result = await _messageService.GetMessageLogTotalCountAsync(new GetMessageLogTotalCountRequest(groupId));
            return Ok(result);
        }

        [HttpPost("get_message_log_list")]
        public async Task<ActionResult> GetMessageLogListAsync(GetMessageLogListViewModel getMessageLogListViewModel)
        {
            var messageLogs = await _messageService.GetMessageLogListAsync(new GetMessageLogListRequest(
                getMessageLogListViewModel.GroupId, 
                getMessageLogListViewModel.StartIndex, 
                getMessageLogListViewModel.PageSize));

            return Ok(messageLogs);
        }

        [HttpGet("get_message_log_list_by_id_range")]
        public async Task<ActionResult> GetMessageLogListByIdRangeAsync(Guid guid, int startId)
        {
            var messageLogs = await _messageService.GetMessageLogListByIdRangeAsync(guid, startId);
            return Ok(messageLogs);
        }
    }
}
