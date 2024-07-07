namespace RudeAnchorSN.DataLayer.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public DateTime Created { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<MessageAttachmentEntity> Attachments { get; set; }
    }
}
