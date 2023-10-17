using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;
using DataService;
using DataClass.Enums;

namespace Core.Services
{
    public class ChatroomService : IChatroomService
    {
        private readonly IChatroomDataService _chatroomDataService;
        private readonly IMapper _mapper;

        public ChatroomService(IChatroomDataService chatroomDataService, IMapper mapper)
        {
            _mapper = mapper;
            _chatroomDataService = chatroomDataService;
        }

        public async Task<ChatroomModel> AddChatroomAsync(AddChatroomRequest addChatroomRequest)
        {
            ChatroomModel chatroom = new()
            {
                ChatroomId = Guid.NewGuid(),
                ChatroomType = ChatroomType.OneToOne
            };

            List<ChatroomMemberModel> chatroomMembers = new(){
                new(){
                    ChatroomId = chatroom.ChatroomId,
                    UserId = addChatroomRequest.UserId
                },
                new(){
                    ChatroomId = chatroom.ChatroomId,
                    UserId = addChatroomRequest.ToUserId
                }
            };

            await _chatroomDataService.AddChatroomAsync(chatroom, chatroomMembers);

            return chatroom;
        }

        public async Task<List<ChatroomModel>> GetChatroomListAsnyc(long userId)
        {
            var chatroomList = await _chatroomDataService.GetChatroomListAsnyc(userId);
            return chatroomList
                    .Where(x => !x.UserId.Equals(userId))
                    .OrderByDescending(x => x.LastLoginTime)
                    .ToList();
        }
    }
}
