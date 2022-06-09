using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            IdFlights = new HashSet<Flight>();
        }

        public int IdPassenger { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PassportNum { get; set; } = null!;

        public virtual ICollection<Flight> IdFlights { get; set; }
    }
}
