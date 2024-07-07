using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IMessageAttachmentRepository
    {
        public Task CreateAttachment(MessageAttachmentEntity attachment);
        public Task<MessageAttachmentEntity> GetAttachment(int id);
        public Task<List<MessageAttachmentEntity>> GetAttachments(int messageId);
    }
}
