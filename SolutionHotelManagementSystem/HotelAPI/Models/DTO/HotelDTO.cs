namespace HotelAPI.Models.DTO
{
    /// <summary>
    /// Data Transfer Object which helps to transfer data between API and Frontend.
    /// </summary>
    public class HotelDTO
    {
        public int Hotel_id { get; set; }
        public string? Hotel_name { get; set; }
        public string? Hotel_phone { get; set; }
        public string? Hotel_address { get; set; }
        public string? amenities { get; set; }
        public double starting_price { get;}

    }
}
