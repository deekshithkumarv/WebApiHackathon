using System;
using System.Collections.Generic;

#nullable disable

namespace BusBooking.DataAccess.Entities
{
    public class BusBooking
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public int IsAvailableBooking { get; set; }
    }
}
