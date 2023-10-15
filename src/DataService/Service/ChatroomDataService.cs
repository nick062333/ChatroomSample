using Adapter;
using Adapter.DBModel;
using Adapter.Interfaces;
using AutoMapper;
using DataClass.Models;

namespace DataService.Service
{
    public class ChatroomDataService : IChatroomDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatroomAdapter _chatroomAdapter;
        private readonly IMapper _mapper;

        public ChatroomDataService(IUnitOfWork unitOfWork, IChatroomAdapter chatroomAdapter, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _chatroomAdapter = chatroomAdapter;
            _mapper = mapper;
        }

        public Task<Chatroom> AddChatroomAsync(params long[] userIds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ChatroomModel>> GetChatroomListAsnyc()
        {
            var chatroomList =  await _chatroomAdapter.GetChatroomListAsnyc();
            return _mapper.Map<List<ChatroomModel>>(chatroomList);
        }
    }
}