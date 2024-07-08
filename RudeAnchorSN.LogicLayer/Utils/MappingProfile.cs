using AutoMapper;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserPostEntity, UserPostModel>().ReverseMap();
        }
    }
}
