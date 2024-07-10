using Microsoft.EntityFrameworkCore;
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

        public async Task AddFriend(int userId, int friendId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var friend = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == friendId);

            user.Friends.Add(friend);
            friend.Friends.Add(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> GetFriends(int userId)
        {
            var all = await _dbContext.UserFriends.ToListAsync();
            var userFriend = all.Where(x => x.UserId == userId)
                .Select(x => x.Friend)
                .ToList();

            return userFriend;
        }

        public async Task RemoveFriend(int userId, int friendId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var friend = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == friendId);

            user.Friends.Remove(friend);
            friend.Friends.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
