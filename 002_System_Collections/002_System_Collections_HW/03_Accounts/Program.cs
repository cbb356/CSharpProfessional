/*
 * Декількома способами створіть колекцію, в якій можна зберігати тільки цілі та речові значення, 
 * на кшталт «рахунок підприємства – доступна сума» відповідно.
 */

using System.Collections;

namespace Accounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating collection with Dictionary<int, decimal> approach
            var accounts1 = new Dictionary<int, decimal>();

            accounts1.Add(1001, 75300.50m);
            accounts1.Add(1002, 120450.25m);
            accounts1.Add(1003, 9810.00m);

            Console.WriteLine("Dictionary<int, decimal> example");
            Console.WriteLine($"Account:\tBalance:");
            foreach (var item in accounts1)
            {
                Console.WriteLine($"{item.Key}\t\t{item.Value}");
            }

            // Creating collection with SortedList<int, decimal> approach
            var accounts2 = new SortedList<int, decimal>();

            accounts2[1003] = 9810.00m;
            accounts2[1002] = 120450.25m;
            accounts2[1001] = 75300.50m;

            Console.WriteLine("\nSortedList<int, decimal> example");
            Console.WriteLine($"Account:\tBalance:");
            foreach (var item in accounts2)
            {
                Console.WriteLine($"{item.Key}\t\t{item.Value}");
            }

            // Creating collection with SortedDictionary<int, decimal> approach
            var accounts3 = new SortedDictionary<int, decimal>()
            {
                { 1002, 120450.25m },
                { 1003, 9810.00m },
                { 1001, 75300.50m }
            };

            Console.WriteLine("\nSortedDictionary<int, decimal> example");
            Console.WriteLine($"Account:\tBalance:");
            foreach (var item in accounts3)
            {
                Console.WriteLine($"{item.Key}\t\t{item.Value}");
            }

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
