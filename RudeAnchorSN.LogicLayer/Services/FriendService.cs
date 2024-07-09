using AutoMapper;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public FriendService(IMapper mapper, IConfiguration config)
        {
            _repository = new FriendRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task AddFriend(Int32 userId, Int32 friendId)
        {
            await _repository.AddFriend(userId, friendId);
        }

        public async Task<List<UserModel>> GetFriends(Int32 userId)
        {
            var _friends = await _repository.GetFriends(userId);

            return _mapper.Map<List<UserModel>>(_friends);
        }
    }
}
