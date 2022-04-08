using System;
using System.Collections.Generic;

#nullable disable

namespace BusBooking.DataAccess.Entities
{
    public partial class Bu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public bool IsAvailableForBooking { get; set; }
    }
}
