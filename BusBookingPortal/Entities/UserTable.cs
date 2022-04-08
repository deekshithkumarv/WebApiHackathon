using System;
using System.Collections.Generic;

namespace BusBookingPortal.Entities
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
