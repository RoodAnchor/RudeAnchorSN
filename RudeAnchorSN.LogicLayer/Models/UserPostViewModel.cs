namespace RudeAnchorSN.LogicLayer.Models
{
    public class UserPostViewModel
    {
        public UserPostViewModel(UserModel author, UserPostModel post) 
        {
            Author = author;
            Post = post;
        }

        public UserModel Author { get; set; }
        public UserPostModel Post { get; set; }
    }
}
