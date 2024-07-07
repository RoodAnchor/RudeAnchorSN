using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IMessageAttachmentRepository
    {
        public Task CreateAttachment(MessageAttachmentEntity attachment);
        public Task<MessageAttachmentEntity> GetAttachment(Guid guid);
        public Task<List<MessageAttachmentEntity>> GetAttachments(Guid messageGuid);
    }
}
