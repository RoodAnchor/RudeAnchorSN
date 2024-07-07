using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class PostAttachmentRepository : IPostAttachmentRepository
    {
        private readonly RSNContext _dbContext;

        public PostAttachmentRepository(RSNContext dbContext) =>
            _dbContext = dbContext;

        public async Task CreateAttachment(PostAttachmentEntity attachment)
        {
            var entry = _dbContext.Entry(attachment);

            if (entry.State == EntityState.Detached)
                await _dbContext.PostAttachments.AddAsync(attachment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PostAttachmentEntity> GetAttachment(Guid guid) =>
            await _dbContext.PostAttachments.FirstOrDefaultAsync(x => x.Guid == guid);

        public async Task<List<PostAttachmentEntity>> GetAttachments(Guid postGuid) =>
            await _dbContext.PostAttachments.Where(x => x.UserPost.Guid == postGuid).ToListAsync();
    }
}
