using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableOrderedDictionary
{
    internal class ValueComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            return (int)x - (int)y;
        }
    }
}
