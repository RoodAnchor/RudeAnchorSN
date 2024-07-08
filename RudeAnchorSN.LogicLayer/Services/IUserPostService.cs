using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IUserPostService
    {
        public Task CreatePost(UserPostModel userPost);
        public Task<UserPostModel> GetPost(int id);
        public Task<List<UserPostModel>> GetPosts(int userId);
        public Task DeletePost(int postId);
    }
}
