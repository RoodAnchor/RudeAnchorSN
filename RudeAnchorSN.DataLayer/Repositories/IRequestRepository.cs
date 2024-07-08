using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IRequestRepository
    {
        public Task CreateRequest(RequestEntity request);
        public Task<RequestEntity> GetRequest(int id);
        public Task<List<RequestEntity>> GetRequests(int ToId);
        public Task UpdateRequst(int id, bool isAccepted);
    }
}
