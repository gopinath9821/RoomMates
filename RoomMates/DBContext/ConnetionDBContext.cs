using RoomMates.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace RoomMates.DBContext
{
    public class ConnetionDBContext:DbContext
    {

        public ConnetionDBContext(DbContextOptions options): base (options)
        {

        }
        public DbSet<User> UserProfile { get; set; }
        public DbSet<SathishShop> SathishShop { get; set; }
        public DbSet<UserShop> OwnUserShop { get; set; }
 
    }
}
