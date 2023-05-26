using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Models
{
    public class HotelContext : DbContext
    {
        //public HotelContext()
        //{
            
        //}
        public HotelContext(DbContextOptions options):base(options)
        { 
            
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(new Hotel()
            {
                Hotel_Id = 101,Hotel_Name = "XYZ Hotel" , Branch_id = 101 , amenities = "AC/Non-AC" , Starting_Price = 2000.0
            });

            modelBuilder.Entity<Branch>().HasData(new Branch()
            {
                Branch_Id = 101 , Branch_Location = "Sholinganallur" , Branch_Name = "Sholinganallur" , Branch_Phone = "9877262516"
            });
        }
    }
}
