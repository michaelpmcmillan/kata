using MikeAndAnt.Api.Models;

namespace MikeAndAnt.Api.Services;

public class SearchService : ISearchService
{
    //private readonly IFlightStore _flightStore;
    //private readonly IHotelStore _hotelStore;
    //private readonly IHolidayPackager _holidayPackager;

    //public SearchService(IFlightStore flightStore, IHotelStore hotelStore, IHolidayPackager holidayPackager)
    //{
    //    _flightStore = flightStore;
    //    _hotelStore = hotelStore;
    //    _holidayPackager = holidayPackager;
    //}

    public async Task<IEnumerable<Package>> Search(string departureAirport, string arrivalAirport, string departureDate, int nights)
    {
        //var flights = await _flightStore.Search(departureAirport, arrivalAirport, departureDate);
        //var hotels = await _hotelStore.Search(arrivalAirport, departureDate, nights);
        //return await _holidayPackager.Package(flights, hotels);

        return await Task.FromResult(
            new[] { new Package(new Flight(2), new Hotel(9)) }
        );
    }
}

public interface IFlightStore
{
    Task<IEnumerable<Flight>> Search(string departureAirport, string arrivalAirport, string departureDate);
}
public interface IHotelStore
{
    Task<IEnumerable<Hotel>> Search(string arrivalAirport, string departureDate, int nights);
}
public interface IHolidayPackager
{
    Task<IEnumerable<Package>> Package(IEnumerable<Flight> flight, IEnumerable<Hotel> hotel);
}