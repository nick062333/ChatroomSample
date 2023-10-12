using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;

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

                CreateMap<MessageLog , MessageLogModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.GroupId, opt => opt.MapFrom(s => s.GroupId))
                .ForMember(x => x.SendUserId, opt => opt.MapFrom(s => s.SendUserId))
                .ForMember(x => x.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(x => x.Message, opt => opt.MapFrom(s => s.Message))
                .ForMember(x => x.SendTime, opt => opt.MapFrom(s => s.SendTime))
                .ForMember(x => x.UserName, opt => opt.MapFrom(s => s.UserName));
        }
 
    }
}