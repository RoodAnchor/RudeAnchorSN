using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IFriendService
    {
        public Task AddFriend(int userId, int friendId);
        public Task<List<UserModel>> GetFriends(int userId);
    }
}
