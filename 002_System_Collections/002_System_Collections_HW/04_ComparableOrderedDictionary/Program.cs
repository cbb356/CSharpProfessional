/*
 * Створіть колекцію типу OrderedDictionary та реалізуйте у ній можливість порівняння значень.
 */

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ComparableOrderedDictionary
{

    internal class Program
    {
        static bool CompareValues(OrderedDictionary collection, object firstKey,  object secondKey)
        {
            if (!collection.Contains(firstKey) || !collection.Contains(secondKey))
            {
                Console.WriteLine("One or both keys do not exist in the collection.");
                return false;
            }
            return collection[firstKey].Equals(collection[secondKey]);
        }

        static void Main(string[] args)
        {
            var orderedDictionary = new OrderedDictionary()
                {
                    { "First", 1 },
                    { "Second", 2 },
                    { "Third", 3 },
                    { "Fourth", 4 },
                    { "Fifth", 5 },
                    { "Sixth", 4 },
                    { "Seventh", 7 },
                    { "Eighth", 8 },
                    { "Ninth", 3 },
                    { "Tenth", 10 }
                };

            Console.WriteLine("The list of elements in OrderedDictionary:");
            foreach (DictionaryEntry entry in orderedDictionary)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            Console.WriteLine();
            Console.WriteLine($"Comparing the values of the \"First\" and \"Second\" keys: {CompareValues(orderedDictionary, "First", "Second")}");
            Console.WriteLine($"Comparing the values of the \"Fourth\" and \"Sixth\" keys: {CompareValues(orderedDictionary, "Fourth", "Sixth")}");
            Console.WriteLine($"Comparing the values of the nonexisted (\"Eleventh\" and \"Twelvth\") keys: {CompareValues(orderedDictionary, "Eleventh", "Twelvth")}");

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
