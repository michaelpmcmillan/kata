using HolidaySearch.Model;

namespace HolidaySearch.Service.PackageHolidayPicker
{
    public interface IPackageHolidayPickerService
    {
        PackageHoliday? Pick(IEnumerable<PackageHoliday> packages);
    }
}