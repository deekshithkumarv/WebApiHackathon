namespace BusBookingPortal.Models
{
    public class BusModel
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Number { get; set; }
            public string? Type { get; set; }
            public int? Seats { get; set; }
            public int? IsAvailable { get; set; }
    }
}
