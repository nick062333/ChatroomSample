using Adapter;
using Adapter.DBModel;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.Models;

namespace DataService.Service
{
    public class ChatroomDataService : IChatroomDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatroomAdapter _chatroomAdapter;
        private readonly IChatroomMemberAdapter _chatroomMemberAdapter;
        private readonly IMapper _mapper;

        public ChatroomDataService(
            IUnitOfWork unitOfWork, 
            IChatroomAdapter chatroomAdapter, 
            IChatroomMemberAdapter chatroomMemberAdapter, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _chatroomAdapter = chatroomAdapter;
            _chatroomMemberAdapter = chatroomMemberAdapter;
            _mapper = mapper;
        }

        public async Task AddChatroomAsync(ChatroomModel chatroomModel)
        {
            var chatroom = _mapper.Map<Chatroom>(chatroomModel);
            var chatroomMember = _mapper.Map<ChatroomMember>(chatroomModel);

            _unitOfWork.BeginTransaction();
            await _chatroomAdapter.AddChatroomAsync(chatroom);
            await _chatroomMemberAdapter.AddChatroomMemberAsync(chatroomMember);
            _unitOfWork.Commit();

        }

        public async Task<List<ChatroomModel>> GetChatroomListAsnyc()
        {
            var chatroomList =  await _chatroomAdapter.GetChatroomListAsnyc();
            return _mapper.Map<List<ChatroomModel>>(chatroomList);
        }
    }
}