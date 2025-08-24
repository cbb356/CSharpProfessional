using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Months
{
    internal readonly struct Month
    {
        public string Name { get; }
        public int Number { get; }
        public int Days { get; }

        public Month(string name, int number, int days)
        {
            Name = name;
            Number = number;
            Days = days;
        }

        public override string ToString()
        {
            return $"{Number}. {Name} - {Days} days";
        }
    }
}
