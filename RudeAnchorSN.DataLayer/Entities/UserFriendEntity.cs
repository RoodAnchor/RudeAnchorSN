namespace RudeAnchorSN.DataLayer.Entities
{
    public class UserFriendEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int FriendId { get; set; }
        public UserEntity Friend { get; set; }
    }
}
