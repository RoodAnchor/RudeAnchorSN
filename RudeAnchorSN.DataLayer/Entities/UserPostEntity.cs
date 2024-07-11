namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserPostEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
