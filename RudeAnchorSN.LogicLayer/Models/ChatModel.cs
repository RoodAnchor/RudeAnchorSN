namespace RudeAnchorSN.LogicLayer.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public List<UserModel> Users { get; set; } = new List<UserModel>();
        public List<MessageModel> Messages { get; set; } = new List<MessageModel>();
        public bool HasNew { get; set; }
    }
}
