namespace HolidaySearch.Data
{
    public class AirportDataProvider : IAirportDataProvider
    {
        public IEnumerable<string> GetAllAirports()
        {
            return new[] { "MAN", "TFS", "AGP", "PMI", "LTN", "LGW", "LPA" };
        }

        public IEnumerable<string> GetLondonAirports()
        {
            return new[] { "LGW", "LTN" };
        }
    }
}