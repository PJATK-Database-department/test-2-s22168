using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class Flight
    {
        public Flight()
        {
            IdPassengers = new HashSet<Passenger>();
        }

        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string? Comments { get; set; }
        public int IdPlane { get; set; }
        public int IdCityDict { get; set; }

        public virtual CityDict IdCityDictNavigation { get; set; } = null!;
        public virtual Plane IdPlaneNavigation { get; set; } = null!;

        public virtual ICollection<Passenger> IdPassengers { get; set; }
    }
}
