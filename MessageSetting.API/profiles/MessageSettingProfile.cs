using AutoMapper;
using MessageSetting.API.Models;
using MessageSetting.Core.Entities;

namespace MessageSetting.API.profiles
{
    public class MessageSettingProfile : Profile
    {
        public MessageSettingProfile()
        {
            CreateMap<Contact, ContactInputModel>().ReverseMap();
            CreateMap<User, UserInputModel>().ReverseMap();
            CreateMap<ContactUser, ContactUserInputModel>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.User.Name))
                .ReverseMap();
        }
    }
}
