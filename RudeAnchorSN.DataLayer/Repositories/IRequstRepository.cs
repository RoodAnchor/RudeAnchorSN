using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IRequstRepository
    {
        public Task CreateRequest(RequestEntity request);
        public Task<RequestEntity> GetRequest(Guid guid);
        public Task<List<RequestEntity>> GetRequests(Guid ToGuid);
        public Task UpdateRequst(Guid guid, bool isAccepted);
    }
}
