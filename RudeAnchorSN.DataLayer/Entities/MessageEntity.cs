namespace RudeAnchorSN.DataLayer.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int AuthorId { get; set; }
        public UserEntity? Author { get; set; }
        public DateTime Created { get; set; }
        public string? Content { get; set; }
    }
}
