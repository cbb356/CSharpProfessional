/*
 * Створіть файл, запишіть у нього довільні дані та закрийте файл. 
 * Потім знову відкрийте цей файл, прочитайте дані і виведіть їх на консоль.
 */

namespace InputOutputFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opening or creating file
            string filePath = Path.Combine(Path.GetTempPath(), "test.txt");
            var file = File.Create(filePath);
            
            // Adding text to file
            var writer = new StreamWriter(file);
            writer.WriteLine("Hello, World!");
            writer.WriteLine("Another text added");

            // File closing
            writer.Close();

            // Reading text from file
            file = File.Open(filePath, FileMode.Open);
            var reader = new StreamReader(file);
            Console.Write(reader.ReadToEnd());

            // File closing
            reader.Close();

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
