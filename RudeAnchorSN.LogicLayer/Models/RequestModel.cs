using RudeAnchorSN.DataLayer.Enums;

namespace RudeAnchorSN.LogicLayer.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public RequestStateEnum RequestState { get; set; }
    }
}
