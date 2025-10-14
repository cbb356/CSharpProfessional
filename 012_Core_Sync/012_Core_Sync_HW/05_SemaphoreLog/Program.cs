/*
 * Створіть Semaphore, що контролює доступу до ресурсу з кількох потоків. 
 * Організуйте впорядкований вивід інформації про отримання доступу до спеціального * .log файлу
 */

using System.Reflection.Metadata;

namespace SemaphoreLog
{
    internal class Program
    {
        private static Semaphore? semaphore;
        private static readonly object locker = new object();
        private static StreamWriter? logWriter;
        private static readonly string logFileName = "console.log";

        static void Function(object number)
        {
            semaphore?.WaitOne();

            Console.WriteLine($"Thread {number} entered");
            LogMessage($"Thread {number} entered");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {number} went out");
            LogMessage($"Thread {number} went out");

            semaphore?.Release();
        }

        static void LogMessage(string message)
        {
            lock (locker)
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                logWriter?.WriteLine($"[{timestamp}] {message}");
            }
        }

        static void Main(string[] args)
        {
            semaphore = new Semaphore(initialCount: 2, maximumCount: 2);

            using (logWriter = new StreamWriter(logFileName))
            {
                Thread[] threads = new Thread[8];

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(Function);
                    threads[i].Start(i + 1);
                }

                foreach (var item in threads)
                {
                    item.Join();
                }
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
