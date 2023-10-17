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

        public async Task AddChatroomAsync(ChatroomModel chatroomModel, List<ChatroomMemberModel> chatroomMemberModels)
        {
            _unitOfWork.BeginTransaction();

            var chatroom = _mapper.Map<Chatroom>(chatroomModel);
            var chatroomMembers = _mapper.Map<List<ChatroomMember>>(chatroomMemberModels);
            await _chatroomAdapter.AddChatroomAsync(chatroom);
            foreach(var member in chatroomMembers){
                await _chatroomMemberAdapter.AddChatroomMemberAsync(member);
            }
            _unitOfWork.Commit();
        }

        public async Task<List<ChatroomModel>> GetChatroomListAsnyc()
        {
            var chatroomList =  await _chatroomAdapter.GetChatroomListAsnyc();
            return _mapper.Map<List<ChatroomModel>>(chatroomList);
        }
    }
}