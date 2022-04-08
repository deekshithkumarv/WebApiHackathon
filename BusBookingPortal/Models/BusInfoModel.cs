namespace BusBookingPortal.Models
{
    public class BusInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Type { get; set; }
        public int? Seats { get; set; }
        public String? IsAvailable { get; set; }
    }
}
