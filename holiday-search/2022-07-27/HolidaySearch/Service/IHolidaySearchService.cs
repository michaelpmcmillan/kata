using HolidaySearch.Model;

namespace HolidaySearch.Service
{
    public interface IHolidaySearchService
    {
        PackageHoliday? Search(SearchCriteria searchCriteria);
    }
}