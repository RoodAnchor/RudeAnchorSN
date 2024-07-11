using RudeAnchorSN.DataLayer.Enums;

namespace RudeAnchorSN.LogicLayer.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int AuthorId { get; set; }
        public UserModel Author { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}
