using Core;
using DataClass.DTOs;
using DataClass.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("insert")]
        [AllowAnonymous]
        public async Task<ActionResult> InsertMessageAsync(Guid groupId,long sendUserId, string message)
        {
            await _messageService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(groupId, sendUserId, message, DateTime.Now));
            
            return Ok();
        }

        [HttpGet("count")]
        public async Task<ActionResult> GetMessageLogTotalCountAsync(Guid groupId)
        {
            var result = await _messageService.GetMessageLogTotalCountAsync(new GetMessageLogTotalCountRequest(groupId));
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetMessageLogListByIdRangeAsync(
            Guid chatroomId, 
            long messageId, 
            QueryModeType queryModeType,
            int maxCount)
        {
            var getMessageLogListByIdRangeRequest = new GetMessageLogListByIdRangeRequest(){
                ChatroomId = chatroomId,
                MessageId = messageId,
                QueryModeType = queryModeType,
                MaxCount = maxCount
            };

            var messageLogs = await _messageService.GetMessageLogListAsync(getMessageLogListByIdRangeRequest);

            return Ok(messageLogs);
        }
    }
}
