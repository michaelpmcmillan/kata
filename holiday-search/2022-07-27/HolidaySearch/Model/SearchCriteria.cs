using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Model
{
    public class SearchCriteria
    {
        public string From { get; }
        public string To { get; }
        public DateTime Date { get; }
        public int Nights { get; }

        public SearchCriteria(string from, string to, DateTime dateTime, int nights)
        {
            From = from;
            To = to;
            Date = dateTime;
            Nights = nights;
        }
    }
}
