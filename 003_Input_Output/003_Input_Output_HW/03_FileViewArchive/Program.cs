/*
 * Напишіть програму для пошуку заданого файлу на диску. 
 * Додайте код, який використовує клас FileStream і дозволяє переглядати файл у текстовому вікні. 
 * Насамкінець додайте можливість стиснення знайденого файлу.
 */

using System.IO;
using System.IO.Compression;

namespace FileViewArchive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating file in Temp directory with text inside
            string filePath = Path.Combine(Path.GetTempPath(), "test03.txt");
            File.WriteAllText(filePath, "Hello, World!\nSome text...");

            string fileNameToFind = "test03.txt";
            string? filePathFound = null;

            // Searching the file
            Console.WriteLine($"Searching \"{fileNameToFind}\" file");
            try
            {
                var files = Directory.EnumerateFiles(Path.GetTempPath(), fileNameToFind, SearchOption.AllDirectories);
                filePathFound = files.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during search: {ex.Message}");
            }

            if (filePathFound == null)
            {
                Console.WriteLine($"File {fileNameToFind} not found");
                return;
            }

            Console.WriteLine($"File found at: {filePathFound}");

            // Delay before viewing
            Console.WriteLine("\nPress any key to view the file");
            Console.ReadKey();

            // Viewing the file
            Console.WriteLine($"Viewing the file {filePathFound}");
            try
            {
                using (FileStream fileStream = new FileStream(filePathFound, FileMode.Open, FileAccess.Read))
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            // Delay before compressing
            Console.WriteLine("\nPress any key to compress the file");
            Console.ReadKey();

            // Compressing the file
            string compressedFilePath = Path.Combine(Path.GetTempPath(), "archive.gz");
            FileStream source = File.OpenRead(filePathFound);
            FileStream destination = File.Create(compressedFilePath);
            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

            Console.WriteLine($"\nCompressing file to: {compressedFilePath}");
            try
            {
                source.CopyTo(compressor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing file: {ex.Message}");
            }
            
            Console.WriteLine("Compression successful!");

            compressor.Close();
            destination.Close();
            source.Close();

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
