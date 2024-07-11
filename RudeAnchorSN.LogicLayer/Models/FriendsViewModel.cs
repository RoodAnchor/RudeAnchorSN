namespace RudeAnchorSN.LogicLayer.Models
{
    public class FriendsViewModel
    {
        public List<UserModel> PendingRequests { get; set; } = new List<UserModel>();
        public List<UserModel> Friends { get; set; } = new List<UserModel>(); 
    }
}
