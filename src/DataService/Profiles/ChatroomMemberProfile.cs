using Adapter.Models;
using AutoMapper;
using DataClass.Models;

namespace DataService.Profiles
{
    public class ChatroomMemberProfile: Profile
    {
        public ChatroomMemberProfile(){
           CreateMap<ChatroomModel , ChatroomMember>()
                .ForMember(x => x.ChatroomId, opt => opt.MapFrom(s => s.ChatroomId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId));
        }   
    }
}