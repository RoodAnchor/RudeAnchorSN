using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IUserRepository
    {
        public Task CreateUser(UserEntity user);
        public Task<UserEntity?> GetUser(int id);
        public Task<UserEntity?> GetUser(string email);
        public Task<List<UserEntity>> GetUsers();
        public Task UpdateUser(UserEntity user);
        public Task DeleteUser(int id);
    }
}
