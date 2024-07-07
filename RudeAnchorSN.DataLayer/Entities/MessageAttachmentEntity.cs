namespace RudeAnchorSN.DataLayer.Entities
{
    public class MessageAttachmentEntity
    {
        public int Id { get; set; }
        public MessageEntity Message { get; set; }
        public Uri Uri { get; set; }
        public string Name { get; set; }
    }
}
