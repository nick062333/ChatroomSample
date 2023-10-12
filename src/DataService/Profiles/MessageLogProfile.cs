using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;

namespace DataService.Profiles
{
    public class MessageLogProfile : Profile
    {
        public MessageLogProfile()
        {
            CreateMap<ReceiveMessageProcessRequest , MessageLog>()
                .ForMember(x => x.GroupId, opt => opt.MapFrom(s => s.GroupId))
                .ForMember(x => x.SendUserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(x => x.Message, opt => opt.MapFrom(s => s.Message))
                .ForMember(x => x.SendTime, opt => opt.MapFrom(s => s.SendTime));
        }
 
    }
}