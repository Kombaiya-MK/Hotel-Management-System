using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options):base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(new Booking()
            {
                BookingId = 101,
                HotelID = 101,
                RoomId = 102,
                NumOfDays = 1
            });
        }
    }
}
