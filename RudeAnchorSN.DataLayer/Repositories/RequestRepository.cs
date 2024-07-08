using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RSNContext _dbContext;

        public RequestRepository(RSNContext context)
        {
            _dbContext = context;
        }

        public async Task CreateRequest(RequestEntity request)
        {
            var entry = _dbContext.Entry(request);

            if (entry.State == EntityState.Detached)
                await _dbContext.Requests.AddAsync(request);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<RequestEntity> GetRequest(int id) =>
            await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<RequestEntity>> GetRequests(int ToId) =>
            await _dbContext.Requests.Where(x => x.ToUserId == ToId).ToListAsync();

        public async Task UpdateRequst(int id, Boolean isAccepted)
        {
            var request = await GetRequest(id);

            if (request is null) throw new RequestNotFoundException();

            request.IsAccepted = isAccepted;

            await _dbContext.SaveChangesAsync();
        }
    }
}
