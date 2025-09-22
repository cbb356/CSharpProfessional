/*
 * Використовуючи приклади, розглянуті на уроці, створіть свій додаток для адміністратора, який 
 * буде зберігати дані конфігурації в спеціальному файлі або в реєстрі. Створіть користувацький 
 * додаток, зовнішнім виглядом якого можна управляти за допомогою адмін-додатку. 
 */

using Microsoft.Extensions.Configuration;

namespace UserApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fgColor = ConsoleColor.Gray;
            var bgColor = ConsoleColor.Black;
            
            string fileName = "config.json";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);

            // Reading config
            if (File.Exists(filePath))
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile(filePath, optional: false, reloadOnChange: true)
                    .Build();

                string ?fgColorString = config["ForegroundColor"];
                string ?bgColorString = config["BackgroundColor"];
                Console.WriteLine("The config file was read");

                if (!Enum.TryParse(fgColorString, ignoreCase: true, out fgColor))
                {
                    Console.WriteLine("The foreground color in config is incorrect. Default value (Gray) was used instead");
                    fgColor = ConsoleColor.Gray;
                }

                if (!Enum.TryParse(bgColorString, ignoreCase: true, out bgColor))
                {
                    Console.WriteLine("The background color in config is incorrect. Default value (Black) was used instead");
                    bgColor = ConsoleColor.Black;
                }
            }
            else
            {
                Console.WriteLine("The config file is not found. Default values (Gray and Black) were used instead");
            }

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;
            Console.WriteLine($"The foreground color set to {fgColor.ToString()}");
            Console.WriteLine($"The background color set to {bgColor.ToString()}");

            Console.ResetColor();

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
