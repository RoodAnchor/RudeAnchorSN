namespace RudeAnchorSN.DataLayer.Entities
{
    public class MessageEntity
    {
        public Guid Guid { get; set; }
        public Guid FromUserGuid { get; set; }
        public Guid ToUserGuid { get; set; }
        public DateTime Created { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<MessageAttachmentEntity> Attachments { get; set; }
    }
}
