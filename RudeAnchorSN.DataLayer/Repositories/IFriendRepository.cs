using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IFriendRepository
    {
        public Task AddFriend(int userId, int friendId);
        public Task RemoveFriend(int userId, int friendId);
        public Task<List<UserEntity?>> GetFriends(int userId);
    }
}
