using HolidaySearch.Model;
using System.Text.Json;

namespace HolidaySearch.Data
{
    public class JsonFileDataProvider : IDataProvider
    {
        private const string FlightsFile = "flights.json";
        private const string HotelsFile = "hotels.json";
        public IEnumerable<Flight> GetFlights()
            => GetData<Flight>(FlightsFile);

        public IEnumerable<Hotel> GetHotels()
            => GetData<Hotel>(HotelsFile);

        private IEnumerable<T> GetData<T>(string filename)
        {
            using (var reader = new StreamReader(GetFullFilePath(filename)))
                return JsonSerializer.Deserialize<T[]>(reader.BaseStream)
                    ?? Enumerable.Empty<T>();
        }

        private string GetFullFilePath(string filename) =>
            Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
    }
}
