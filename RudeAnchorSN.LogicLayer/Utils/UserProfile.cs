using AutoMapper;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Utils
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
        }
    }
}
