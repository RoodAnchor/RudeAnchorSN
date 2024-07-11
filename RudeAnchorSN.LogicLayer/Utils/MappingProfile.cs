using AutoMapper;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(x => x.Requests, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserPostEntity, UserPostModel>()
                .ReverseMap();

            CreateMap<RequestEntity, RequestModel>()
                .ReverseMap();

            CreateMap<ChatEntity, ChatModel>()
                .ReverseMap();

            CreateMap<MessageEntity, MessageModel>()
                .ReverseMap();
        }
    }
}