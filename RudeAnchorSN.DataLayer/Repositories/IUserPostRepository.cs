using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IUserPostRepository
    {
        public Task CreatePost(UserPostEntity userPost);
        public Task<UserPostEntity> GetPost(int id);
        public Task<List<UserPostEntity>> GetPosts(int userId);
        public Task UpdatePost(UserPostEntity userPost);
        public Task DeletePost(int id);
    }
}
