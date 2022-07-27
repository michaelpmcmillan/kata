using HolidaySearch.Model;

namespace HolidaySearch.Data
{
    public interface IDataProvider
    {
        IEnumerable<Hotel> GetHotels();
        IEnumerable<Flight> GetFlights();
    }
}