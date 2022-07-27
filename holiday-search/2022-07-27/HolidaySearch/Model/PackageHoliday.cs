using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Model
{
    public class PackageHoliday
    {
        public PackageHoliday(Flight flight, Hotel hotel, int price)
        {
            Flight = flight;
            Hotel = hotel;
            Price = price;
        }

        public Flight Flight { get; }
        public Hotel Hotel { get; }
        public int Price { get; }
    }
}
