using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RSNContext _dbContext;

        public UserRepository(RSNContext dbContext) =>
            _dbContext = dbContext;

        public async Task CreateUser(UserEntity user)
        {
            var entry = _dbContext.Entry(user);

            if (entry.State == EntityState.Detached)
                await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserEntity> GetUser(Guid guid) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Guid == guid);

        public async Task<UserEntity> GetUser(string email) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<List<UserEntity>> GetUsers() =>
            await _dbContext.Users.ToListAsync();

        public async Task UpdateUser(UserEntity user)
        {
            var _user = await GetUser(user.Guid);

            if (_user is null) throw new UserNotFoundException();

            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.AvatarUrl = user.AvatarUrl;

            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteUser(Guid guid)
        {
            var user = await GetUser(guid);

            if (user is null) throw new UserNotFoundException();

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
