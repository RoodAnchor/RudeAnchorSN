﻿namespace RudeAnchorSN.LogicLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ProfilePicUrl { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age 
        { 
            get 
            {
                return (DateTime.Now - BirthDate).Days / 365;
            } 
        }
        public List<UserModel> Requests { get; set; } = new List<UserModel>();
        public List<UserPostModel> Posts { get; set; } = new List<UserPostModel>();
        public List<UserModel> Friends { get; set; } = new List<UserModel>();
        public List<ChatModel> Chats { get; set; } = new List<ChatModel>();
    }
}
