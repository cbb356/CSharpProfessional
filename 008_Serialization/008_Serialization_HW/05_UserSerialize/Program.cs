/*
 * Створіть  користувацький  тип  (наприклад,  клас)  і  виконайте  серіалізацію  об’єкта  цього  типу, 
 * враховуючи той факт, що стан об’єкту необхідно передати по мережі.  
 */
using System.CodeDom.Compiler;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;

namespace UserSerialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            { 
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@test.com"            
            };

            // Serialize to XML with SOAP formatter 
            using (FileStream stream = new FileStream("User.xml", FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, user);
            }

            Console.WriteLine($"'{typeof(User).Name}' SOAP serialization completed");

            // Serialize to JSON
            using (FileStream stream = new FileStream("User.json", FileMode.Create))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                JsonSerializer.Serialize<User>(stream, user, options);
            }

            Console.WriteLine($"'{typeof(User).Name}' JSON serialization completed");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
