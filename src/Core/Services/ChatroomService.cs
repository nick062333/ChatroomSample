using Adapter.DBModel;
using AutoMapper;
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

        public async Task<Chatroom> AddChatroomAsync(params long[] userIds)
        {
            throw new NotImplementedException();
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
