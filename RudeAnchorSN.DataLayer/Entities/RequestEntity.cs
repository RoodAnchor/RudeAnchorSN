using RudeAnchorSN.DataLayer.Enums;

namespace RudeAnchorSN.DataLayer.Entities
{
    public class RequestEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public UserEntity Friend { get; set; }
        public RequestStateEnum RequestState { get; set; } = RequestStateEnum.Pending;
    }
}
