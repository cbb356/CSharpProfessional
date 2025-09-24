/*
 * Створіть програму, яка надає користувачеві доступ до складання з Завдання 2. 
 * Реалізуте метод перетворення  значення  температури  з  Цельсія  у  Фаренгейт.  
 * При виконанні завдання використовуйте лише рефлексію. 
 */

using System.Reflection;

namespace TemperatureConverter

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly ?assembly = null;

            try
            {
                // Load the assembly from file
                assembly = Assembly.LoadFrom("02_TemperatureConverterLibrary.dll");
                Console.WriteLine("Loaded TemperatureConverterLibrary assembly");

                // Get the type of the class
                Type? converterType = assembly.GetType("TemperatureConverterLibrary.Temperature");
                if (converterType == null)
                {
                    Console.WriteLine("Could not find the 'Temperature' type");
                    return;
                }

                // Create an instance of the class
                object? converterInstance = Activator.CreateInstance(converterType);

                // Get the method for calling
                MethodInfo? method = converterType.GetMethod("CelsiusToFahrenheit");

                // Call the method with parameter
                object[] parameters = { 20.5m };
                object? result = method.Invoke(converterInstance, parameters);

                Console.WriteLine($"20,5 Celsius is {result:0.##} Fahrenheit");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
