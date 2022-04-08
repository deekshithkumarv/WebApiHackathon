using System.ComponentModel.DataAnnotations;

namespace BusWebAPI
{
    public class busbooking
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Bus_No { get; set; }
        public string Type { get; set; }
        public int seats { get; set; }
        public string isAvailable { get; set; }
        public string Source { get; set; }
        public string Destinaton { get; set; }

        public DateTime Date { get; set; }
    }
}
