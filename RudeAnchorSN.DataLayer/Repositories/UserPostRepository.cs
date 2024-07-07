using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly RSNContext _dbContext;

        public UserPostRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RSNContext>()
               .UseSqlServer(connectionString);

            _dbContext = new RSNContext(optionsBuilder.Options);
        }

        public async Task CreatePost(UserPostEntity userPost)
        {
            var entry = _dbContext.Entry(userPost);

            if (entry.State == EntityState.Detached)
                await _dbContext.UserPosts.AddAsync(userPost);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePost(Guid guid)
        {
            var post = await _dbContext.UserPosts.FirstOrDefaultAsync(x => x.Guid == guid);

            if (post is null) throw new PostNotFoundException();

            _dbContext.UserPosts.Remove(post);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserPostEntity> GetPost(Guid guid) =>
            await _dbContext.UserPosts.FirstOrDefaultAsync(x => x.Guid == guid);

        public async Task<List<UserPostEntity>> GetPosts(Guid userGuid) =>
            await _dbContext.UserPosts.Where(x => x.UserGuid == userGuid).ToListAsync();

        public async Task UpdatePost(UserPostEntity userPost)
        {
            var post = await GetPost(userPost.Guid);

            if (post is null) throw new PostNotFoundException();

            post.Content = userPost.Content;

            await _dbContext.SaveChangesAsync();
        }
    }
}
