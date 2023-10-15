using Core;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    /// <summary>
    /// 聊天室群組
    /// </summary>
    public class ChatroomController : BaseController
    {
        private readonly IChatroomService _chatroomService;

        public ChatroomController(IChatroomService chatroomService)
        {
            _chatroomService = chatroomService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetListAsync()
        {
            var chatroomList = await _chatroomService.GetChatroomListAsnyc(GetUserId());
            return Ok(chatroomList);
        }
    }
}