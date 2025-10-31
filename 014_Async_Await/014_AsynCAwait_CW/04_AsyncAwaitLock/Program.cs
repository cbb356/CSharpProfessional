/*
 * Переробіть додаткове завдання з уроку 11 із використанням конструкції async await.
 */

namespace AsyncAwaitLock
{
    internal class Program
    {
        static int counter = 0;
        static object fileLock = new object();

        static void FunctionAsync(int taskId)
        {
            lock (fileLock)
            {
                Console.WriteLine($"\nTask {taskId} started");
                for (int i = 0; i < 50; ++i)
                {
                    Console.WriteLine($"Task {taskId} is working. Counter: {++counter}");
                    Thread.Sleep(10);
                }
                Console.WriteLine($"Task {taskId} finished");
            }
        }

        static async Task Main()
        {
            Console.WriteLine($"Main started");

            Task[] tasks = {
                new Task(() => FunctionAsync(1)),
                new Task(() => FunctionAsync(2)),
                new Task(() => FunctionAsync(3))
            };

            foreach (var task in tasks)
            {
                task.Start();
            }

            await Task.WhenAll(tasks);

            Console.WriteLine($"\nMain finished");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}