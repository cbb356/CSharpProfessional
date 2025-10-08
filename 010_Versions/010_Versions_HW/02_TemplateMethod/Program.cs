/*
 * Вивчіть опис шаблону Template method (Шаблонний метод). Зверніть увагу на застосування шаблону, 
 * а також на склад його учасників і зв'язку відносини між ними. Напишіть невелику програму мовою C#, 
 * що є абстрактною реалізацією даного шаблону. 
 */

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentPrinter[] printer = { new XMLDocumentPrinter(), new TxtDocumentPrinter() };
            foreach (var item in printer)
            {
                item.PrintDocument();
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
