/*
 * Використовуючи клас SortedList, створіть невелику колекцію та виведіть 
 * на екран значення пар «ключ-значення» спочатку в алфавітному порядку, а потім у зворотному.
 */

using System.Collections;
using System.Collections.Generic;

namespace SortedListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating SortedList collection
            SortedList sortedList1 = new SortedList();

            sortedList1.Add("One", 1);
            sortedList1.Add("Two", 2);
            sortedList1.Add("Three", 3);

            Console.WriteLine("The list of elements of the SortedList:");
            foreach (DictionaryEntry entry in sortedList1)
            {
                Console.WriteLine($"Key: { entry.Key}, Value: { entry.Value}");
            }

            Console.WriteLine("\nThe reversed list of elements of the SortedList");
            for (int i = sortedList1.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"Key: {sortedList1.GetKey(i)}, Value: {sortedList1.GetByIndex(i)}");
            }

            // Creating SortedList<string, int> collection
            SortedList<string, int> sortedList2 = new SortedList<string, int>();

            sortedList2.Add("One", 1);
            sortedList2.Add("Two", 2);
            sortedList2.Add("Three", 3);

            Console.WriteLine("\nThe list of elements of the SortedList<string, int>:");
            foreach (var item in sortedList2)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine("\nThe reversed list of elements of the SortedList<string, int>");

            foreach (var item in sortedList2.Reverse())
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
