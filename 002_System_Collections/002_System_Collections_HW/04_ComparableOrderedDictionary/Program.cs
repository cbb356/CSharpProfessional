/*
 * Створіть колекцію типу OrderedDictionary та реалізуйте у ній можливість порівняння значень.
 */

using System.Collections;
using System.Collections.Specialized;

namespace ComparableOrderedDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderedDictionary = new OrderedDictionary()
            {
                { "First", 1 },
                { "Second", 2 },
                { "Third", 3 },
                { "Fourth", 4 },
                { "Fifth", 5 }
            };

            

            




            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
