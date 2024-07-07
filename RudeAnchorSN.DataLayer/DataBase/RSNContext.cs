using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.DataBase
{
    public class RSNContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserPostEntity> UserPosts { get; set; }
        public DbSet<PostAttachmentEntity> PostAttachments { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<MessageAttachmentEntity> MessageAttachments { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }

        public RSNContext(DbContextOptions<RSNContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
