using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;
using RudeAnchorSN.DataLayer.Enums;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RSNContext _dbContext;

        public RequestRepository(RSNContext context)
        {
            _dbContext = context;
        }

        public async Task CreateRequest(int userId, int friendId)
        {
            var friend = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == friendId) 
                ?? throw new UserNotFoundException();

            var newRequest = new RequestEntity() 
            {
                UserId = userId,
                FriendId = friendId
            };

            friend.Requests.Add(newRequest);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserEntity?>> GetPending(int userId)
        {
            var all = await _dbContext.Requests.ToListAsync();
            var pending = all.Where(x => 
                    x.UserId == userId && x.RequestState == RequestStateEnum.Pending)
                .Select(x => x.Friend).ToList();

            return pending;
        }

        public async Task<RequestEntity?> GetRequest(int userId, int friendId) =>
            await _dbContext.Requests
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FriendId == friendId && x.RequestState == RequestStateEnum.Pending);

        public async Task Update(int reqestId, RequestStateEnum requestState)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == reqestId)
                ?? throw new RequestNotFoundException();

            request.RequestState = requestState;

            await _dbContext.SaveChangesAsync();
        }
    }
}
