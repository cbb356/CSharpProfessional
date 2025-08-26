using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Translation
    {
        public string Russian { get; set; }
        public string English { get; set; }

        public Translation(string russian, string english)
        {
            Russian = russian;
            English = english;
        }
    }

    public enum TranlationLanguage
    {
        Russian,
        English
    }
}
