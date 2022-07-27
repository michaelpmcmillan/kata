using HolidaySearch.Data;
using HolidaySearch.Model;

namespace HolidaySearch.Service.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly IDataProvider _dataProvider;

        public HotelService(IDataProvider dataProvider) =>
            _dataProvider = dataProvider;

        public IEnumerable<Hotel> GetHotels(string destinationAirport, int nights, DateTime arrivalDate) =>
            _dataProvider
                .GetHotels()
                .Where(hotel =>
                    hotel.LocalAirports.Contains(destinationAirport) &&
                    hotel.Nights == nights &&
                    hotel.ArrivalDate == arrivalDate);
    }
}