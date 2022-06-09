namespace Test2.CustomDTOs
{
    public class FlightDto
    {
        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string? Comments { get; set; }
        public int IdPlane { get; set; }
        public int IdCityDict { get; set; }
        public string Name { get; set; } = null!;
        public int MaxSeats { get; set; }
    }
}
