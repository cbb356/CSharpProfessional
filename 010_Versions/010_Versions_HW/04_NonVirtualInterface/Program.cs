/*
 * Реалізуйте шаблон NVI у власній ієрархії успадкування.
 */

namespace NonVirtualInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentProcessor[] processor = { new DocumentProcessor(), new PDFProcessor(), new WordProcessor() };
            foreach (var item in processor)
            {
                item.Process();
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
