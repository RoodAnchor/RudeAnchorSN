using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RSNContext _dbContext;

        public UserRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RSNContext>()
               .UseSqlServer(connectionString);

            _dbContext = new RSNContext(optionsBuilder.Options);
        }
            

        public async Task CreateUser(UserEntity user)
        {
            var entry = _dbContext.Entry(user);

            if (entry.State == EntityState.Detached)
                await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserEntity> GetUser(int id) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<UserEntity> GetUser(string email) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<List<UserEntity>> GetUsers() =>
            await _dbContext.Users.ToListAsync();

        public async Task UpdateUser(UserEntity user)
        {
            var _user = await GetUser(user.Id);

            if (_user is null) throw new UserNotFoundException();

            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.AvatarUrl = user.AvatarUrl;

            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteUser(int id)
        {
            var user = await GetUser(id);

            if (user is null) throw new UserNotFoundException();

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
