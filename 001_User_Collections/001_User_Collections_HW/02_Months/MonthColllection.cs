using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Months
{
    internal class MonthColllection
    {
        private Month[] _months;

        public MonthColllection()
        {
            _months = new Month[]
            {
                new Month("January", 1, 31),
                new Month("February", 2, 28),
                new Month("March", 3, 31),
                new Month("April", 4, 30),
                new Month("May", 5, 31),
                new Month("June", 6, 30),
                new Month("July", 7, 31),
                new Month("August", 8, 31),
                new Month("September", 9, 30),
                new Month("October", 10, 31),
                new Month("November", 11, 30),
                new Month("December", 12, 31)
            };
        }

        public Month GetMonthByNumber(int number)
        { 
            return _months.First(m => m.Number == number); 
        }

        public IEnumerable<Month> GetMonthsByDays(int days)
        { 
            return _months.Where(m => m.Days == days);
        }
        
    }
}
