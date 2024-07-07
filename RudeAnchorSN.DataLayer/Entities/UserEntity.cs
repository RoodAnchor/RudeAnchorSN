namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserEntity
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastOnline { get; set; }
    }
}
