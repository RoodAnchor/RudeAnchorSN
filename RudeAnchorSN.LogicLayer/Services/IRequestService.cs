using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IRequestService
    {
        public Task SendRequest(int userId, int friendId);
        public Task<RequestModel> GetRequest(int userId, int friendId);
        public Task<List<UserModel>> GetPending(int userId);
        public Task Accept(int id);
        public Task Reject(int id);
    }
}
