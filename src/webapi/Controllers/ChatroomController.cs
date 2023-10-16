using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModels.Chatroom;

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
        public async Task<ActionResult> CreateAsync(AddChatroomModel addChatroomModel)
        {
            var chatroom = await _chatroomService.AddChatroomAsync(new AddChatroomRequest(){
                UserId = addChatroomModel.UserId
            });

            return Ok(chatroom);
        }

        [HttpGet]
        public async Task<ActionResult> GetListAsync()
        {
            var chatroomList = await _chatroomService.GetChatroomListAsnyc(GetUserId());
            return Ok(chatroomList);
        }
    }
}