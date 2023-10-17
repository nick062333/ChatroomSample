using Adapter;
using Adapter.DBModel;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.Enums;
using DataClass.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DataService.Service
{
    public class ChatroomDataService : IChatroomDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatroomAdapter _chatroomAdapter;
        private readonly IChatroomMemberAdapter _chatroomMemberAdapter;
        private readonly IUserAdapter _userAdapter;
        private readonly IMapper _mapper;

        public ChatroomDataService(
            IUnitOfWork unitOfWork, 
            IChatroomAdapter chatroomAdapter, 
            IChatroomMemberAdapter chatroomMemberAdapter, 
            IUserAdapter userAdapter, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _chatroomAdapter = chatroomAdapter;
            _chatroomMemberAdapter = chatroomMemberAdapter;
            _userAdapter = userAdapter;
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

        public async Task<ChatroomModel> GetChatroomAsync(long userId, long toUserId)
        {
            var chatrooms = await GetChatroomListByUserIdAsync(userId);
            return chatrooms.FirstOrDefault(x => x.UserId == toUserId && x.ChatroomId != Guid.Empty);
        }

        public async Task<List<ChatroomModel>> GetChatroomListAsync(long userId)
        {
            return await GetChatroomListByUserIdAsync(userId);
        }

        private async Task<List<ChatroomModel>> GetChatroomListByUserIdAsync(long userId)
        {
            var users = await _userAdapter.GetUserAsync();
            var chatroomList =  await _chatroomAdapter.GetChatroomListAsnyc();

            var result = new List<ChatroomModel>();

            var chatrooms = chatroomList
                .GroupBy(x => new { x.ChatroomId, x.ChatroomType })
                .Select(x => new Chatroom { Id = x.Key.ChatroomId, ChatroomType = x.Key.ChatroomType, UserIds = x.Select(x =>　x.UserId).ToList() });

            foreach(var user in users)
            {
                var chatroom = chatrooms.Where(x => x.UserIds.Contains(userId) && x.UserIds.Contains(user.Id)).FirstOrDefault();

                result.Add(new ChatroomModel(){
                    ChatroomId = chatroom == null ? Guid.Empty : chatroom.Id,
                    UserId = user.Id,
                    UserName = user.UserName,
                    ChatroomType = chatroom == null ? ChatroomType.Unbeknown : chatroom.ChatroomType
                });
            }

            return result;
        }
    }
}