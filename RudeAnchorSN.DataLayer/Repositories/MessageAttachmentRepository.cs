using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class MessageAttachmentRepository : IMessageAttachmentRepository
    {
        private readonly RSNContext _dbContext;

        public MessageAttachmentRepository(RSNContext dbContext) =>
            _dbContext = dbContext;

        public async Task CreateAttachment(MessageAttachmentEntity attachment)
        {
            var entry = _dbContext.Entry(attachment);

            if (entry.State == EntityState.Detached)
                await _dbContext.MessageAttachments.AddAsync(attachment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<MessageAttachmentEntity> GetAttachment(Guid guid) =>
            await _dbContext.MessageAttachments.FirstOrDefaultAsync(x => x.Guid == guid);

        public async Task<List<MessageAttachmentEntity>> GetAttachments(Guid messageGuid) =>
            await _dbContext.MessageAttachments.Where(x => x.Message.Guid == messageGuid).ToListAsync();
        
    }
}
