/*
 * Переробіть додаткове завдання з уроку 11 із використанням конструкції async await.
 */

namespace AsyncAwaitLock
{
    internal class Program
    {
        static int counter = 0;
        static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        static async Task FunctionAsync(int taskId)
        {
            await semaphore.WaitAsync();

            try
            {
                Console.WriteLine($"\nTask {taskId} started");
                for (int i = 0; i < 50; ++i)
                {
                    Console.WriteLine($"Task {taskId} is working. Counter: {++counter}");
                    await Task.Delay(10);
                }
                Console.WriteLine($"Task {taskId} finished");
            }
            finally
            {
                semaphore.Release();
            }

        }

        static async Task Main()
        {
            Console.WriteLine($"Main started");

            Task[] tasks = { FunctionAsync(1), FunctionAsync(2), FunctionAsync(3) };

            await Task.WhenAll(tasks);

            Console.WriteLine($"\nMain finished");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
