namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserPostEntity
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime DateCreated { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<PostAttachmentEntity> Attachments { get; set; }
    }
}
