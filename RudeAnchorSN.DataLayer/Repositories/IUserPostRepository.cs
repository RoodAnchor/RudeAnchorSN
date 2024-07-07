using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IUserPostRepository
    {
        public Task CreatePost(UserPostEntity userPost);
        public Task<UserPostEntity> GetPost(Guid guid);
        public Task<List<UserPostEntity>> GetPosts(Guid userGuid);
        public Task UpdatePost(UserPostEntity userPost);
        public Task DeletePost(Guid guid);
    }
}
