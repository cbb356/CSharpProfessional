/*
 * Створіть два методи, які виконуватимуться у межах паралельних завдань. 
 * Організуйте виклик цих методів за допомогою Invoke таким чином, 
 * щоб основний потік програми (метод Main) не зупинив виконання.
 */

namespace ParallelMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
