using AutoMapper;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.DataLayer.Exceptions;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Utils;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IMapper mapper, IConfiguration config)
        {
            _repository = new UserRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserModel?> GetUser(string? email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            var _user = await _repository.GetUser(email);

            if (_user is null)
                throw new UserNotFoundException();

            var user = _mapper.Map<UserModel>(_user);

            return user;
        }

        public async Task<UserModel?> GetUser(int id)
        {
            var _user = await _repository.GetUser(id);

            if (_user is null)
                throw new UserNotFoundException();

            var user = _mapper.Map<UserModel>(_user);

            return user;
        }

        public async Task<List<UserModel>> GetUsers(int currentUserId)
        {
            var _users = await _repository.GetUsers();
            var users = _mapper
                .Map<List<UserModel>>(_users)
                .Where(x => x.Id != currentUserId)
                .ToList();

            return users;
        }

        public async Task RegisterUser(UserModel user)
        {
            var _user = _mapper.Map<UserEntity>(user);

            _user.Registered = DateTime.Now;
            _user.Password = PasswordUtils.GetPasswordHash(user.Password);

            await _repository.CreateUser(_user);
        }

        public async Task<UserModel?> AuthenticateUser(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Неверный запрос");

            var user = await GetUser(email);

            if (user is null) throw new AuthenticationException($"Пользователь {email} не найден");

            if (user.Password != PasswordUtils.GetPasswordHash(password))
                throw new AuthenticationException($"Неверный пароль");

            user.LastOnline = DateTime.Now;

            await _repository.UpdateUser(_mapper.Map<UserEntity>(user));

            return user;
        }

        public async Task UpdateUser(UserModel user)
        {
            var _user = _mapper.Map<UserEntity>(user);

            await _repository.UpdateUser(_user);
        }
    }
}
