/*
 * Створіть клас, який дозволить виконувати моніторинг ресурсів, що використовуються програмою. 
 * Використовуйте його з метою спостереження за роботою програми, а саме: користувач може вказати 
 * прийнятні рівні споживання ресурсів (пам'яті), а методи класу дозволять видати попередження, 
 * коли кількість ресурсів, що реально використовуються, наблизитися до максимально допустимого рівня.
 */

namespace MemoryMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter maximum allowed memory in MB (positive number bigger than 0):");
            if (!int.TryParse(Console.ReadLine(), out int memoryMax) || memoryMax <= 0)
            {
                Console.WriteLine("Wrong input for maximum memory");
                return;
            }

            Console.WriteLine("Enter warning threshold in percents (1 - 100):");
            if (!int.TryParse(Console.ReadLine(), out int warningThreshold) || (warningThreshold < 1 || warningThreshold > 100))
            {
                Console.WriteLine("Wrong input for warning threshold");
                return;
            }

            Monitor monitor = new Monitor(memoryMax, warningThreshold / 100);

            // Simulate memory workloa
            var memoryConsumer = new List<byte[]>();

            try
            {
                for (int i = 0; i < 20; i++)
                {
                    memoryConsumer.Add(new byte[1024 * 1024 * 10]);
                    Thread.Sleep(500);
                    monitor.CheckMemoryUsage();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
