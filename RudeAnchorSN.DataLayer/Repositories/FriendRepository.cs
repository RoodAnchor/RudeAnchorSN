using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly RSNContext _dbContext;

        public FriendRepository(RSNContext context)
        {
            _dbContext = context;
        }

        public async Task AddFriend(Int32 userId, Int32 friendId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            var friend = _dbContext.Users.FirstOrDefault(x => x.Id == friendId);

            user.Friends.Add(friend);

            _dbContext.SaveChanges();
        }

        public async Task<List<UserEntity>> GetFriends(Int32 userId)
        {
            var friends = _dbContext.UserFriends.Where(x => x.UserId == userId).Select(x => x.Friend).ToList();

            return friends;
        }

        public Task RemoveFriend(Int32 userId, Int32 friendId)
        {
            throw new NotImplementedException();
        }
    }
}
