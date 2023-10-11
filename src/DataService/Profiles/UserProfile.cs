using Adapter.Models;
using AutoMapper;
using DataClass.Models;

namespace DataService.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User , UserModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Account, opt => opt.MapFrom(s => s.Account))
                .ForMember(x => x.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(x => x.UserName, opt => opt.MapFrom(s => s.UserName));
        }
    }
}