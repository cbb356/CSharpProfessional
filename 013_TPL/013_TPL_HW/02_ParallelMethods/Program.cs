/*
 * Створіть два методи, які виконуватимуться у межах паралельних завдань. 
 * Організуйте виклик цих методів за допомогою Invoke таким чином, 
 * щоб основний потік програми (метод Main) не зупинив виконання.
 */

namespace ParallelMethods
{
    internal class Program
    {
        static void Method1()
        {
            Console.WriteLine($"Method1 started");
            Thread.Sleep(1000);
            Console.WriteLine($"Method1 completed");
        }

        static void Method2()
        {
            Console.WriteLine($"Method2 started");
            Thread.Sleep(1500);
            Console.WriteLine($"Method2 completed");
        }

        static void Main(string[] args)
        {
            Task task = new Task(() => Parallel.Invoke(Method1, Method2));
            task.Start();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main doing work {i}");
                Thread.Sleep(300);
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
