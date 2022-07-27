namespace HolidaySearch.Data
{
    public interface IAirportDataProvider
    {
        IEnumerable<string> GetLondonAirports();
        IEnumerable<string> GetAllAirports();
    }
}