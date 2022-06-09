using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }

        public int IdPlane { get; set; }
        public string Name { get; set; } = null!;
        public int MaxSeats { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
