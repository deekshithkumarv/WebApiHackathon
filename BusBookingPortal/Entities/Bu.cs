using System;
using System.Collections.Generic;

namespace BusBookingPortal.Entities
{
    
       
        public partial class Bu
        {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Seat { get; set; }
        public bool? Isavailableforbooking { get; set; }
    }
}
