namespace RudeAnchorSN.LogicLayer.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public List<UserModel> Users { get; set; }
        public List<MessageModel> Messages { get; set; }
        public bool HasNew { get; set; }
    }
}
