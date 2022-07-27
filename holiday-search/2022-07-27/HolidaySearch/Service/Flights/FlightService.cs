using HolidaySearch.Data;
using HolidaySearch.Model;

namespace HolidaySearch.Service.Flights
{
    public class FlightService : IFlightService
    {
        private const string LondonAirportCode = "LONDON";
        private const string AnyAirportCode = "ANY";

        private readonly IDataProvider _dataProvider;
        private readonly IAirportDataProvider _airportDataProvider;

        public FlightService(IDataProvider dataProvider, IAirportDataProvider airportDataProvider)
        {
            _dataProvider = dataProvider;
            _airportDataProvider = airportDataProvider;
        }

        public IEnumerable<Flight> GetFlights(string departureAirport, string destinationAirport, DateTime departureDate)
        {
            var departureAirports = ExpandAirports(departureAirport);
            var destinationAirports = ExpandAirports(destinationAirport);

            return _dataProvider
                .GetFlights()
                .Where(flight =>
                    departureAirports.Contains(flight.From) &&
                    destinationAirports.Contains(flight.To) &&
                    flight.DepartureDate == departureDate);
        }

        private IEnumerable<string> ExpandAirports(string airport)
        {
            if (airport == LondonAirportCode)
            {
                return _airportDataProvider.GetLondonAirports();
            }
            else if (airport == AnyAirportCode)
            {
                return _airportDataProvider.GetAllAirports();
            }
            return new[] { airport };
        }
    }
}