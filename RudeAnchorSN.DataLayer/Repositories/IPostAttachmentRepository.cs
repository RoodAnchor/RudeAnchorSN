using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IPostAttachmentRepository
    {
        public Task CreateAttachment(PostAttachmentEntity attachment);
        public Task<PostAttachmentEntity> GetAttachment(Guid guid);
        public Task<List<PostAttachmentEntity>> GetAttachments(Guid postGuid);
    }
}
