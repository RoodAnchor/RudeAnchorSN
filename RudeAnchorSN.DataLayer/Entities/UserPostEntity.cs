namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserPostEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<PostAttachmentEntity> Attachments { get; set; }
    }
}
