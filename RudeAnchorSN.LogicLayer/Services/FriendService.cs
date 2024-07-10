using AutoMapper;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public FriendService(IMapper mapper, IConfiguration config)
        {
            _friendRepository = new FriendRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task AddFriend(int userId, int friendId)
        {
            await _friendRepository.AddFriend(userId, friendId);
        }

        public async Task RemoveFriend(int userId, int friendId)
        {
            await _friendRepository.RemoveFriend(userId, friendId);
        }

        public async Task<List<UserModel>> GetFriends(int userId)
        {
            var _friends = await _friendRepository.GetFriends(userId);

            return _mapper.Map<List<UserModel>>(_friends);
        }
    }
}
