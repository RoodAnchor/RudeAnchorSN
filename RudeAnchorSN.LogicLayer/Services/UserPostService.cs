using AutoMapper;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.DataLayer.Exceptions;
using RudeAnchorSN.LogicLayer.Models;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserPostService(IMapper mapper, IConfiguration config)
        {
            _repository = new UserPostRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task CreatePost(UserPostModel post)
        {
            var _post = _mapper.Map<UserPostEntity>(post);

            await _repository.CreatePost(_post);
        }

        public async Task<UserPostModel> GetPost(int id) 
        {
            var _post = await _repository.GetPost(id);

            if (_post is null)
                throw new PostNotFoundException();

            return _mapper.Map<UserPostModel>(_post);
        }

        public async Task<List<UserPostModel>> GetPosts(int userId)
        {
            var _posts = await _repository.GetPosts(userId);

            return _mapper.Map<List<UserPostModel>>(_posts);
        }

        public async Task DeletePost(int id)
        {
            await _repository.DeletePost(id);
        }
    }
}
