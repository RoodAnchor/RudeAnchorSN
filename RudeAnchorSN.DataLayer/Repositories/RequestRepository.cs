using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class RequestRepository : IRequstRepository
    {
        private readonly RSNContext _dbContext;

        public RequestRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RSNContext>()
               .UseSqlServer(connectionString);

            _dbContext = new RSNContext(optionsBuilder.Options);
        }

        public async Task CreateRequest(RequestEntity request)
        {
            var entry = _dbContext.Entry(request);

            if (entry.State == EntityState.Detached)
                await _dbContext.Requests.AddAsync(request);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<RequestEntity> GetRequest(Guid guid) =>
            await _dbContext.Requests.FirstOrDefaultAsync(x => x.Guid == guid);

        public async Task<List<RequestEntity>> GetRequests(Guid ToGuid) =>
            await _dbContext.Requests.Where(x => x.ToUserGuid == ToGuid).ToListAsync();

        public async Task UpdateRequst(Guid guid, Boolean isAccepted)
        {
            var request = await GetRequest(guid);

            if (request is null) throw new RequestNotFoundException();

            request.IsAccepted = isAccepted;

            await _dbContext.SaveChangesAsync();
        }
    }
}
