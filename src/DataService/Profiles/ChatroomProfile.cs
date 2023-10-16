using Adapter.DBModel;
using Adapter.Models;
using AutoMapper;
using DataClass.Models;

namespace DataService.Profiles
{
    public class ChatroomProfile : Profile
    {
        public ChatroomProfile()
        {
            CreateMap<ChatroomMember, ChatroomModel>()
                .ForMember(x => x.ChatroomId, opt => opt.MapFrom(s => s.ChatroomId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(x => x.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(x => x.LastLoginTime, opt => opt.MapFrom(s => s.LastLoginTime));

            CreateMap<ChatroomModel, Chatroom>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.ChatroomId))
                .ForMember(x => x.ChatroomType, opt => opt.MapFrom(s => s.ChatroomType));
        }   
    }
}