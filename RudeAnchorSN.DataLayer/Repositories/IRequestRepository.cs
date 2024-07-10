using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Enums;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IRequestRepository
    {
        public Task CreateRequest(int userId, int friendId);
        public Task<RequestEntity?> GetRequest(int userId, int friendId);
        public Task<List<UserEntity>> GetPending(int userId);
        public Task Update(int reqestId, RequestStateEnum requestState);
    }
}
