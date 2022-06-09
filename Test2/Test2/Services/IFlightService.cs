using System.Collections.Generic;
using Test2.CustomDTOs;
using Test2.Models;

namespace Test2.Services
{
    public interface IFlightService
    {
        public IEnumerable<Flight> GetByCity(string name);
        public  Task AddFilght(FlightDto name);
    }
    public class FlightService : IFlightService
    {
        private test_dbContext _db;
        public FlightService(test_dbContext db)
        {
            _db = db;
        }
        public async Task AddFilght(FlightDto flight)
        {
            if(_db.Planes.Where(e=>e.IdPlane == flight.IdPlane)==null)
            {
                await _db.Planes.AddAsync(new Plane() { IdPlane = flight.IdPlane, MaxSeats = flight.MaxSeats, Name = flight.Name });
            }
            await _db.Flights.AddAsync(new Flight { IdPlane = flight.IdPlane, Comments = flight.Comments, FlightDate = flight.FlightDate, IdCityDict = flight.IdCityDict });
        }

        public IEnumerable<Flight> GetByCity(string name)// as i understood there can be several flights to one city
        {
           var city = _db.CityDicts.Where(e => e.Name == name).FirstOrDefault();
            if (city == null)
            {
                throw new Exception();
            }
            foreach(var x in  _db.Flights.Where(e=>e.IdCityDict == city.IdCityDict))
            {
                yield return x; //the data about passenger is stored in Models.Flight.IdPassengers and will retrieve all possible data about passenger from there
            }

        }
    }
}
