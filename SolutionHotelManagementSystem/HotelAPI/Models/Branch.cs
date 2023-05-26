using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }

        [Required]
        public string Branch_Name { get; set; }
        [Required]
        public string Branch_Location { get; set;}

      

    }
}
