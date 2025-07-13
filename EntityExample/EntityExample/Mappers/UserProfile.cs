using AutoMapper;
using EntityExample.Data.Entities;
using EntityExample.Models;

namespace EntityExample.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserItemModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FistName} {src.LastName}"));
    }
}
