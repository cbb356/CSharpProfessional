/*
 * Використовуючи приклади, розглянуті на уроці, створіть свій додаток для адміністратора, який 
 * буде зберігати дані конфігурації в спеціальному файлі або в реєстрі. Створіть користувацький 
 * додаток, зовнішнім виглядом якого можна управляти за допомогою адмін-додатку. 
 */

using System.Text.Json;

namespace AdminApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "config.json";

            // Setting foreground color
            Console.Write("Enter text color (White, Gray, Yellow, Red, Green, Cyan, etc): ");
            string ?fgColor = Console.ReadLine();

            if (!Enum.TryParse(fgColor, ignoreCase: true, out ConsoleColor parsedFgColor))
            {
                Console.WriteLine("Invalid color, using default Gray.");
                fgColor = "Gray";
            }
            else
            {
                fgColor = parsedFgColor.ToString();
            }

            // Setting background color
            Console.Write("Enter background color (White, Yellow, Red, Green, Cyan, Black, etc): ");
            string ?bgColor = Console.ReadLine();

            if (!Enum.TryParse(bgColor, ignoreCase: true, out ConsoleColor parsedBgColor))
            {
                Console.WriteLine("Invalid color, using default Black.");
                bgColor = "Black";
            }
            else
            {
                bgColor = parsedBgColor.ToString();
            }

            // Creating config
            var config = new Config { ForegroundColor = fgColor, BackgroundColor = bgColor};

            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

            // Saving config
            string filePath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"\nConfig saved at {filePath}");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
