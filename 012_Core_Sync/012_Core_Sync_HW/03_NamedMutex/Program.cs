/*
 * Створіть програму, яка може бути запущена лише в одному екземплярі (використовуючи іменований Mutex).
 */

namespace NamedMutex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "MyMutex"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Another program instance already running");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Only one program instance running");
                Console.ResetColor();

                // Delay    
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                mutex.ReleaseMutex();
            }
        }
    }
}
