namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ProfilePicUrl { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime BirthDate { get; set; }
        public List<RequestEntity> Requests { get; set; } = new List<RequestEntity>();
        public List<UserEntity> Friends { get; set; } = new List<UserEntity>();
        public List<UserPostEntity> Posts { get; set; } = new List<UserPostEntity>();
        public List<ChatEntity> Chats { get; set; } = new List<ChatEntity> { };
    }
}
