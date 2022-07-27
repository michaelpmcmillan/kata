using HolidaySearch.Model;

namespace HolidaySearch.Service.Flights
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights(string departureAirport, string destinationAirport, DateTime departureDate);
    }
}