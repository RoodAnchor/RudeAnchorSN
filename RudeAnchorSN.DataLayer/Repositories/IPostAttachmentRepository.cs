using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IPostAttachmentRepository
    {
        public Task CreateAttachment(PostAttachmentEntity attachment);
        public Task<PostAttachmentEntity> GetAttachment(int id);
        public Task<List<PostAttachmentEntity>> GetAttachments(int postId);
    }
}
