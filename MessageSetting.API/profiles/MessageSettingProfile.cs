using AutoMapper;
using MessageSetting.API.Models;
using MessageSetting.Core.Entities;

namespace MessageSetting.API.profiles
{
    public class MessageSettingProfile : Profile
    {
        public MessageSettingProfile()
        {
            CreateMap<Contact, ContactModel>()
                .ForMember(dest => dest.PrimaryUserName,src=>src.MapFrom(x=>x.ContactUsers.FirstOrDefault(y=>y.UserType==1).User.Name))
                .ForMember(dest => dest.PrimaryUserId, src => src.MapFrom(x => x.ContactUsers.FirstOrDefault(y => y.UserType == 1).User.Id))

                .ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<ContactUser, ContactUserModel>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.User.Name))

                .ReverseMap();
        }
    }
}
