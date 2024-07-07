using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IMapper mapper) 
        {
            _repository = new UserRepository(configuration.GetConnectionString("DefaultConnection"));
            _mapper = mapper;
        }

        public async Task<UserModel> GetUser(String email)
        {
            var _user = await _repository.GetUser(email);
            var user = _mapper.Map<UserModel>(_user);

            return user;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var _users = await _repository.GetUsers();
            var users = _mapper.Map<List<UserModel>>(_users);

            return users;
        }

        public async Task RegisterUser(UserModel user)
        {
            var _user = _mapper.Map<UserEntity>(user);

            await _repository.CreateUser(_user);
        }
    }
}
