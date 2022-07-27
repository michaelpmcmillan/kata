using HolidaySearch.Model;

namespace HolidaySearch.Service.Hotels
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetHotels(string destinationAirport, int nights, DateTime arrivalDate);
    }
}