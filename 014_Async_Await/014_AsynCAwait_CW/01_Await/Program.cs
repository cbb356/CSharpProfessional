using System.Threading.Tasks;

namespace _01_Await
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main started in {Thread.CurrentThread.ManagedThreadId}");
            var operationTask = OperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main {i}");
                Thread.Sleep(300);
            }
            int result = await operationTask;
            Console.WriteLine(value: $"Result: {result}");
            Console.WriteLine($"Main finished in {Thread.CurrentThread.ManagedThreadId}");

            // Delay
            Console.ReadKey();
        }

        public static async Task<int> OperationAsync()
        {
            Console.WriteLine($"OperationAsync started in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"OperationAsync {i}");
                Thread.Sleep(500);
            }
            int result = await Task.Run(Operation);
            Console.WriteLine($"OperationAsync finished in {Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public static int Operation()
        {
            Console.WriteLine($"Operation started in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Operation {i}");
                Thread.Sleep(400);
            }
            Console.WriteLine($"Operation finished in {Thread.CurrentThread.ManagedThreadId}");
            return 2;
        }
    }
}
