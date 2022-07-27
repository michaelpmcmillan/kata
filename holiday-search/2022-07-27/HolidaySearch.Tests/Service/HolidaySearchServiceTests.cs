using AutoFixture;
using FluentAssertions;
using HolidaySearch.Data;
using HolidaySearch.Model;
using HolidaySearch.Service;
using HolidaySearch.Service.Flights;
using HolidaySearch.Service.Hotels;
using HolidaySearch.Service.PackageHolidayPicker;

namespace HolidaySearch.Tests.Service
{
    public class HolidaySearchServiceTests
    {
        private readonly CheapestPackageHolidayPickerService _cheapestHolidayPickerService;
        private readonly JsonFileDataProvider _dataProvider;
        private readonly AirportDataProvider _airportDataProvider;
        private readonly HotelService _hotelService;
        private readonly FlightService _flightService;
        private readonly HolidaySearchService _holidaySearchService;

        public HolidaySearchServiceTests()
        {
            _cheapestHolidayPickerService = new CheapestPackageHolidayPickerService();
            _dataProvider = new JsonFileDataProvider();
            _airportDataProvider = new AirportDataProvider();
            _hotelService = new HotelService(_dataProvider);
            _flightService = new FlightService(_dataProvider, _airportDataProvider);
            _holidaySearchService = new HolidaySearchService(_hotelService, _flightService, _cheapestHolidayPickerService);
        }

        [Theory]
        [InlineData("MAN", "AGP", "2023-07-01", 7, 2, 9)]
        [InlineData("LONDON", "PMI", "2023-06-15", 10, 6, 5)]
        [InlineData("ANY", "LPA", "2022-11-10", 14, 7, 6)]
        public void GivenSearchCriteria_WhenSearch_ThenExpectedPackageReturned(
            string from, string to, string date, int nights,
            int expectedFlightId, int expectedHotelId)
        {
            var searchCriteria = new SearchCriteria(from, to, DateTime.Parse(date), nights);

            var result = _holidaySearchService.Search(searchCriteria);

            result.Should().NotBeNull();
            result!.Flight.Id.Should().Be(expectedFlightId);
            result!.Hotel.Id.Should().Be(expectedHotelId);
        }

        [Theory]
        [InlineData("UNKNOWN", "LPA", "2022-11-10", 14)]
        [InlineData("ANY", "LPA", "2022-11-10", 20)]
        [InlineData("ANY", "UNKNOWN", "2022-11-10", 14)]
        [InlineData("ANY", "LPA", "2050-11-10", 14)]
        public void GivenSearchCriteria_ThatDoesNotMatchOurData_WhenSearch_ThenReturnedPackageShouldBeNull(
            string from, string to, string date, int nights)
        {
            var searchCriteria = new SearchCriteria(from, to, DateTime.Parse(date), nights);

            var result = _holidaySearchService.Search(searchCriteria);

            result.Should().BeNull();
        }
    }
}