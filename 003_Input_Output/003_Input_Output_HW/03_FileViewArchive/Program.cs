/*
 * Напишіть програму для пошуку заданого файлу на диску. 
 * Додайте код, який використовує клас FileStream і дозволяє переглядати файл у текстовому вікні. 
 * Насамкінець додайте можливість стиснення знайденого файлу.
 */

namespace FileViewArchive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileNameToFind = "test03.txt";
            bool fileFound = false;

            // Searching the file
            Console.WriteLine($"Searching {fileNameToFind} file");
            try
            {
                var files = Directory.EnumerateFiles(Path.GetTempPath(), fileNameToFind, SearchOption.AllDirectories);
                foreach (var item in files)
                {
                    Console.WriteLine($"Found: {item}");
                    fileFound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if ( !fileFound )
            {
                Console.WriteLine($"File {fileNameToFind} not found");
            }
            else
            {
                var streamReader = new StreamReader()
            }



                // Delay.
                Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
