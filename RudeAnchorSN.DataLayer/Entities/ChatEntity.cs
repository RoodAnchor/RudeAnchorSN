namespace RudeAnchorSN.DataLayer.Entities
{
    public class ChatEntity
    {
        public int Id { get; set; }
        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public List<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        public bool HasNew { get; set; }
    }
}