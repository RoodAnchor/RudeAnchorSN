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

        public async Task DeletePost(int id)
        {
            var post = await _dbContext.UserPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (post is null) throw new PostNotFoundException();

            _dbContext.UserPosts.Remove(post);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserPostEntity> GetPost(int id) =>
            await _dbContext.UserPosts.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<UserPostEntity>> GetPosts(int userId) =>
            await _dbContext.UserPosts.Where(x => x.UserId == userId).ToListAsync();

        public async Task UpdatePost(UserPostEntity userPost)
        {
            var post = await GetPost(userPost.Id);

            if (post is null) throw new PostNotFoundException();

            post.Content = userPost.Content;

            await _dbContext.SaveChangesAsync();
        }
    }
}
