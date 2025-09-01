/*
 * Використовуючи клас SortedList, створіть невелику колекцію та виведіть 
 * на екран значення пар «ключ-значення» спочатку в алфавітному порядку, а потім у зворотному.
 */

using System.Collections;

namespace SortedListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList = new SortedList();

            sortedList.Add("One", 1);
            sortedList.Add("Two", 2);
            sortedList.Add("Three", 3);

            Console.WriteLine("The list of elements of the SortedList:");
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("\nThe reversed list of elements of the SortedList");
            for (int i = sortedList.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{sortedList.GetKey(i)}: {sortedList.GetByIndex(i)}");
            }

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
