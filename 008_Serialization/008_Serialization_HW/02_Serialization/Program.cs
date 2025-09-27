/*
 * Створіть клас, що підтримує серіалізацію. Виконайте серіалізацію об’єкту цього класу в форматі 
 * XML. Спочатку використайте формат за замовчуванням, а далі змініть його таким чином, щоб 
 * значення полів зберігалось в вигляді атрибутів елементів XML. 
 */

using System.Xml.Serialization;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Serialize Person with Elements
            PersonElements personElements = new PersonElements { Name = "John Doe", Age = 20};
            using (FileStream stream = new FileStream("PersonElements.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonElements));
                xmlSerializer.Serialize(stream, personElements);
            }

            Console.WriteLine($"{personElements} serialization completed");

            // Serialize Person with Attributes
            PersonAttributes personAttributes = new PersonAttributes() { Name = "Mary Shelly", Age = 21};
            using (FileStream stream = new FileStream("PersonAttributes.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonAttributes));
                xmlSerializer.Serialize(stream, personAttributes);
            }

            Console.WriteLine($"{personAttributes} serialization completed");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
