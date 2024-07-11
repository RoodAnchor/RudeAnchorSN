namespace RudeAnchorSN.LogicLayer.Models
{
    public class UserPostModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
