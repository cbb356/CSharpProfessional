/*
 * Створіть .xml файл, який би відповідав наступним вимогам:
 * • ім'я файлу: TelephoneBook.xml
 * • кореневий елемент: “MyContacts”
 * • тег “Contact”, і в ньому має бути записано ім'я контакту та атрибут “TelephoneNumber” 
 * зі значенням номера телефону.
 */

using System.Xml;

namespace TelephoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "TelephoneBook.xml";
            using (var xmlWriter = new XmlTextWriter(fileName, null))
            {
                xmlWriter.Formatting = Formatting.Indented;

                xmlWriter.WriteStartDocument();                     //  Start document
                xmlWriter.WriteStartElement("MyContacts");          //  <MyContacts>     
                xmlWriter.WriteStartElement("Contact");             //      <Contact>
                xmlWriter.WriteAttributeString("TelephoneNumber", "1234567891");    // attribute TelephoneNumber for Contact
                xmlWriter.WriteString("John Smith");                //          John Smith
                xmlWriter.WriteEndElement();                        //      </Contact>
                xmlWriter.WriteStartElement("Contact");             //      <Contact>
                xmlWriter.WriteAttributeString("TelephoneNumber", "1234567892");    // attribute TelephoneNumber for Contact
                xmlWriter.WriteString("Mary Shelly");               //          Mary Shelly
                xmlWriter.WriteEndElement();                        //      </Contact>   
                xmlWriter.WriteStartElement("Contact");             //      <Contact>
                xmlWriter.WriteAttributeString("TelephoneNumber", "1234567893");    // attribute TelephoneNumber for Contact
                xmlWriter.WriteString("Michael Kelly");             //          Michael Kelly
                xmlWriter.WriteEndElement();                        //      </Contact>   
                xmlWriter.WriteEndElement();                        //  </MyContacts>
            }

            Console.WriteLine($"File \"{fileName}\" created");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
