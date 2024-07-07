using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IUserService
    {
        public Task RegisterUser(UserModel user);
        public Task<UserModel> GetUser(string email);
        public Task<List<UserModel>> GetUsers();
    }
}
