/*
 * Створіть  консольний  додаток,  який  в  різних  потоках  зможе  отримати  доступ  до  двох  файлів.
 * Зчитайте  з  цих  файлів  їх  вміст  і  спробуйте  записати  отриману  інформацію  в  третій  файл.
 * Читання/запис повинні здійснюватися одночасно в кожному з дочірніх потоків. Використовуйте 
 * блокування потоків для того, щоб домогтися коректного запису в кінцевий файл. 
 */

namespace ReadWriteToFile
{
    internal class Program
    {
        private static object fileLock = new object();
        private static readonly string outputFile = "output.txt";

        static void ReadAndWrite(string inputFile)
        {
            try
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} started reading from {inputFile}");

                // Read content from input file
                string content = File.ReadAllText(inputFile);

                lock (fileLock)
                {
                    Console.WriteLine($"{Thread.CurrentThread.GetHashCode()} writing to {outputFile}");

                    // Write to output file
                    using (StreamWriter sw = File.AppendText(outputFile))
                    {
                        sw.WriteLine(content);
                    }

                    Console.WriteLine($"{Thread.CurrentThread.GetHashCode()} finished writing");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Thread.CurrentThread.GetHashCode()} Error: {ex.Message}");
            }
        }

        static void ReadAndWriteFileOne()
        {
            ReadAndWrite("file1.txt");
        }

        static void ReadAndWriteFileTwo()
        {
            ReadAndWrite("file2.txt");
        }

        static void Main(string[] args)
        {
            // Create threads for reading and writing
            Thread thread1 = new Thread(ReadAndWriteFileOne);
            Thread thread2 = new Thread(ReadAndWriteFileTwo);

            // Clear output file before starting
            File.WriteAllText(outputFile, string.Empty);

            Console.WriteLine("Starting threads...\n");

            // Start both threads
            thread1.Start();
            thread2.Start();

            // Wait for both threads to complete
            thread1.Join();
            thread2.Join();

            Console.WriteLine($"\nFinal output written to: {outputFile}");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
