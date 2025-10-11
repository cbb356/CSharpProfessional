/*
 * Використовуючи конструкції блокування, модифікуйте останній приклад уроку таким чином, 
 * щоб отримати можливість послідовної роботи 3-х потоків. 
 */

namespace MonitorLock
{
    class Program
    {
        static int counter = 0;
        static object block = new object();

        static void Function()
        {
            Monitor.Enter(block);
            
            Console.WriteLine($"\nThread {Thread.CurrentThread.GetHashCode()} started");
            
            for (int i = 0; i < 50; ++i)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} is working. Counter: {++counter}");
                Thread.Sleep(10);
            }
            
            Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} finished");
            
            Monitor.Exit(block);
        }

        static void Main()
        {
            Console.WriteLine($"Main thread started");

            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            // Start all threads
            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            // Wait for finishing all threads
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"\nMain thread finished");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
