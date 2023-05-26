using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    /// <summary>
    /// Model Class for the hotel object
    /// </summary>
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }

        [Required]
        public string Hotel_Name { get;set; }
        public string? Hotel_Description { get; set; }

        [ForeignKey(nameof(Branch))]
        public int Branch_id { get; set; }

        public string? amenities { get; set; }
        public double Starting_Price { get; set; }



    }
}
