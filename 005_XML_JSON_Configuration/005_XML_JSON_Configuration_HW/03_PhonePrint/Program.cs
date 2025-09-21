/*
 * З файлу TelephoneBook.xml (файл повинен був бути створений у процесі виконання 
 * додаткового завдання) виведіть на екран лише номери телефонів.
 */
using System.Reflection.PortableExecutable;
using System.Xml;

namespace PhonePrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var xmlReader = new XmlTextReader("TelephoneBook.xml"))
            {
                Console.WriteLine("List of phone numbers:");
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlReader.Name.Equals("Contact"))
                        {
                            Console.WriteLine(xmlReader.GetAttribute("TelephoneNumber"));
                        }
                    }
                }
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
