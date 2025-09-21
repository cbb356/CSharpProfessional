/*
 * Створіть програму, яка виводить на екран всю інформацію про вказаний .xml файл.
 */

using System.Reflection.PortableExecutable;
using System.Xml;

namespace XMLInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "TelephoneBook.xml";
            using (var xmlReader = new XmlTextReader(xmlFilePath))
            {
                Console.WriteLine($"Content of the {xmlFilePath}:");

                while (xmlReader.Read())
                {
                    // Creating the indent
                    string indent = new string('\t', xmlReader.Depth);

                    switch (xmlReader.NodeType)
                    { 
                        case XmlNodeType.Element:
                            Console.WriteLine($"{indent}Element: <{xmlReader.Name}>");
                            if (xmlReader.HasAttributes)
                            {
                                while (xmlReader.MoveToNextAttribute())
                                {
                                    Console.WriteLine($"{indent}  Attribute: {xmlReader.Name} = \"{xmlReader.Value}\"");
                                }
                                xmlReader.MoveToElement();
                            }
                            break;

                        case XmlNodeType.Text:
                            Console.WriteLine($"{indent}Text: {xmlReader.Value}");
                            break;

                        case XmlNodeType.EndElement:
                            Console.WriteLine($"{indent}End Element: </{xmlReader.Name}>");
                            break;

                        case XmlNodeType.XmlDeclaration:
                            Console.WriteLine($"XML Declaration: <?{xmlReader.Name} {xmlReader.Value}?>");
                            break;

                        case XmlNodeType.Whitespace:
                            break;
                    }
                }
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
