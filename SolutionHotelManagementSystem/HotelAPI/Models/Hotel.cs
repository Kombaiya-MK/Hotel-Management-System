using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get;set; }
        public string? Hotel_Description { get; set; }

        [ForeignKey(nameof(Branch))]
        public int Branch_id { get; set; }


    }
}
