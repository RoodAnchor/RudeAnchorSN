using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.DataBase
{
    public class RSNContext : DbContext
    {
        private static RSNContext _instance;

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserFriendEntity> UserFriends { get; set; }        
        public DbSet<UserPostEntity> UserPosts { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }

        private RSNContext(DbContextOptions<RSNContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Friends)
                .WithMany()
                .UsingEntity<UserFriendEntity>(
                    x => x.HasOne<UserEntity>(y => y.User).WithMany().HasForeignKey(y => y.UserId),
                    x => x.HasOne<UserEntity>(y => y.Friend).WithMany().HasForeignKey(y => y.FriendId));
        }

        public static RSNContext GetInstance(IConfiguration configuration)
        {
            if(_instance is null)
                _instance = new RSNContext(new DbContextOptionsBuilder<RSNContext>()
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        opts => opts.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                    .Options);

            return _instance;
        }
    }
}
