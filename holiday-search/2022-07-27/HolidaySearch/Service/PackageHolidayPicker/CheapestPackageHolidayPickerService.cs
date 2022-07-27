using HolidaySearch.Model;

namespace HolidaySearch.Service.PackageHolidayPicker
{
    public class CheapestPackageHolidayPickerService : IPackageHolidayPickerService
    {
        public PackageHoliday? Pick(IEnumerable<PackageHoliday> packages)
        {
            if (!packages.Any()) return null;

            return packages.OrderBy(p => p.Price).First();
        }
    }
}