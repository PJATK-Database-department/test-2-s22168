using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class CityDict
    {
        public CityDict()
        {
            Flights = new HashSet<Flight>();
        }

        public int IdCityDict { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
