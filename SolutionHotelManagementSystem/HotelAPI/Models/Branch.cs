using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    /// <summary>
    /// Branch Object which is used to store the branch and location details of 
    /// </summary>
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }

        [Required]
        public string Branch_Name { get; set; }
        [Required]
        public string Branch_Location { get; set;}

        [Required]
        public string Branch_Phone { get; set;}

      

    }
}
