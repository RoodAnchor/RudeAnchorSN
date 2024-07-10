using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IUserService
    {
        public Task RegisterUser(UserModel user);
        public Task<UserModel> GetUser(string email);
        public Task<UserModel> GetUser(int id);
        public Task<List<UserModel>> GetUsers(int currentUserId);
        public Task<UserModel> AuthenticateUser(string email, string password);
        public Task UpdateUser(UserModel user);
    }
}
