using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;
using DataService;

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
                UserId = addChatroomRequest.UserId
            };

            await _chatroomDataService.AddChatroomAsync(chatroom);

            return chatroom;
        }

        public async Task<List<ChatroomModel>> GetChatroomListAsnyc(long userId)
        {
            var chatroomList = await _chatroomDataService.GetChatroomListAsnyc();
            return chatroomList
                    .Where(x => !x.UserId.Equals(userId))
                    .OrderByDescending(x => x.LastLoginTime)
                    .ToList();
        }
    }
}
