/*
 *  Створіть на диску 100 директорій із іменами від Folder_0 до Folder_99, потім видаліть їх.
 */
using System.IO;

namespace Directories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string basePath = Path.Combine(Path.GetTempPath(), "directories");
            var directory = new DirectoryInfo(basePath);

            // Creating directories
            if (!directory.Exists)
            {
                directory.Create();
                Console.WriteLine($"Directory: {directory.FullName} created");
            }

            for (int i = 0; i < 100; i++)
            {
                directory.CreateSubdirectory($"Folder_{i}");
            }
            Console.WriteLine("Folders created");

            Console.WriteLine($"List of folders inside {directory.FullName}");
            foreach (string subdirectory in Directory.GetDirectories(basePath))
            {
                Console.WriteLine($"{subdirectory} ");
            }

            // Delay before deleting
            Console.WriteLine("\nPress any key to delete directories");
            Console.ReadKey();

            // Deleting directories
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Directory.Delete(@$"{basePath}\Folder_{i}", true);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            Console.WriteLine("Folders deleted");

            Console.WriteLine($"List of folders inside {directory.FullName}");
            foreach (string subdirectory in Directory.GetDirectories(basePath))
            {
                Console.WriteLine($"{subdirectory} ");
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
