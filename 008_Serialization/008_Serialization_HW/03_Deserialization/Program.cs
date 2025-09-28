/*
 * Створіть  новий  додаток,  в  котрому  виконайте  десеріалізацію  об’єкту  з  попереднього  прикладу. 
 * Відобразіть стан об’єкту на екрані. 
 */
using System.Xml.Serialization;
using Serialization;

namespace Deserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deserialize Person with Elements
            PersonElements personElements = new PersonElements();
            try
            {
                using (FileStream stream = new FileStream("PersonElements.xml", FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonElements));
                    personElements = (PersonElements)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"'{typeof(PersonElements).Name}' deserialization completed");
            Console.WriteLine(personElements);

            // Deserialize Person with Attributes
            PersonAttributes personAttributes = new PersonAttributes();
            try
            {
                using (FileStream stream = new FileStream("PersonAttributes.xml", FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonAttributes));
                    personAttributes = (PersonAttributes)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"'{typeof(PersonAttributes).Name}' deserialization completed");
            Console.WriteLine(personAttributes);

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
