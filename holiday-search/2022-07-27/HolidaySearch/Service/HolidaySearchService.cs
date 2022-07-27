using HolidaySearch.Model;
using HolidaySearch.Service.Flights;
using HolidaySearch.Service.Hotels;
using HolidaySearch.Service.PackageHolidayPicker;

namespace HolidaySearch.Service
{
    public class HolidaySearchService : IHolidaySearchService
    {
        private readonly IHotelService _hotelService;
        private readonly IFlightService _flightService;
        private readonly IPackageHolidayPickerService _packageHolidayPickerService;

        public HolidaySearchService(
            IHotelService hotelService,
            IFlightService flightService,
            IPackageHolidayPickerService packageHolidayPickerService)
        {
            _hotelService = hotelService;
            _flightService = flightService;
            _packageHolidayPickerService = packageHolidayPickerService;
        }

        public PackageHoliday? Search(SearchCriteria searchCriteria)
        {
            IEnumerable<Hotel> hotels = _hotelService.GetHotels(searchCriteria.To, searchCriteria.Nights, searchCriteria.Date);
            IEnumerable<Flight> flights = _flightService.GetFlights(searchCriteria.From, searchCriteria.To, searchCriteria.Date);

            var packages = GetPackageHolidays(hotels, flights);

            return _packageHolidayPickerService.Pick(packages);
        }

        private IEnumerable<PackageHoliday> GetPackageHolidays(IEnumerable<Hotel> hotels, IEnumerable<Flight> flights)
        {
            foreach (var hotel in hotels)
            {
                foreach (var localAirport in hotel.LocalAirports)
                {
                    foreach (var flight in flights)
                    {
                        yield return new PackageHoliday(flight, hotel, flight.Price + hotel.Price * hotel.Nights);
                    }
                }
            }
        }
    }
}