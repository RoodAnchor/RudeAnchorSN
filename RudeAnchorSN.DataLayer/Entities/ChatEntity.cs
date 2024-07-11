namespace RudeAnchorSN.DataLayer.Entities
{
    public class ChatEntity
    {
        public int Id { get; set; }
        public List<UserEntity> Users { get; set; }
        public List<MessageEntity> Messages { get; set; }
        public bool HasNew { get; set; }
    }
}
