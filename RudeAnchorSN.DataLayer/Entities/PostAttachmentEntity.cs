namespace RudeAnchorSN.DataLayer.Entities
{
    public class PostAttachmentEntity
    {
        public Guid Guid { get; set; }
        public UserPostEntity UserPost { get; set; }
        public Uri Uri { get; set; }
        public string Name { get; set; }
    }
}
