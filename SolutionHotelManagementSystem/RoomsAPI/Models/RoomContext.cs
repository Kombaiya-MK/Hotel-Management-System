using Microsoft.EntityFrameworkCore;

namespace RoomsAPI.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions options):base(options) 
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(new Room()
            {
                HotelId = 101,
                RoomID = 101,
                RoomStatus = true,
                RoomType = "Single",
                RoomDescription = "AC/Room Service/Wi-fi",
                RoomPrice = 5000.0
            });
        }
    }
}
