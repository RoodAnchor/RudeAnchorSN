namespace RudeAnchorSN.DataLayer.Entities
{
    public class PostAttachmentEntity
    {
        public int Id { get; set; }
        public UserPostEntity UserPost { get; set; }
        public Uri Uri { get; set; }
        public string Name { get; set; }
    }
}
