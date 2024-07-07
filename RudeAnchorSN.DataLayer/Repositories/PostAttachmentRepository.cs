using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class PostAttachmentRepository : IPostAttachmentRepository
    {
        private readonly RSNContext _dbContext;

        public PostAttachmentRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RSNContext>()
               .UseSqlServer(connectionString);

            _dbContext = new RSNContext(optionsBuilder.Options);
        }

        public async Task CreateAttachment(PostAttachmentEntity attachment)
        {
            var entry = _dbContext.Entry(attachment);

            if (entry.State == EntityState.Detached)
                await _dbContext.PostAttachments.AddAsync(attachment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PostAttachmentEntity> GetAttachment(int id) =>
            await _dbContext.PostAttachments.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<PostAttachmentEntity>> GetAttachments(int postId) =>
            await _dbContext.PostAttachments.Where(x => x.UserPost.Id == postId).ToListAsync();
    }
}
