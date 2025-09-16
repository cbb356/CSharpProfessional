/*
 * Напишіть жартівливу програму «Дешифратор», яка в текстовому файлі могла б замінити всі 
 * прийменники на слово «ГАВ!».
 */

using System.Text;
using System.Text.RegularExpressions;

namespace Decoder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Creating the file with text
            string originalFile = "text.txt";
            StringBuilder fileText = new StringBuilder();
            fileText.Append("Струмок біг по камінню, створюючи ніжний шум. ").
            Append("Над водою схилились верби, що їхні гілки торкались поверхні, ").
            Append("а під ними ховалася риба. У глибині виднілися мушлі.");
            string textString = fileText.ToString();
            File.WriteAllText(originalFile, textString);

            // Reading the file and replacing prepositions
            string originalText = File.ReadAllText(originalFile);
            Console.WriteLine($"Content of the {originalFile} file:\n");
            Console.WriteLine($"{originalText}\n");

            string[] prepositions =
            {
                "без", "біля", "в", "від", "для", "до", "за", "з", "із", "зі", 
                "коло", "крім", "кругом", "між", "на", "над", "навколо", "назустріч", 
                "о", "обабіч", "об", "по", "побіля", "повз", "поміж", "що",
                "поперед", "посеред", "після", "при", "проти", "про", "через", "щодо", 
                "у", "крізь", "перед", "понад", "попід", "побік", "під"
            };
            string pattern = $@"\b({string.Join("|", prepositions)})\b";
            string decodedText = Regex.Replace(originalText, pattern, "ГАВ!", RegexOptions.IgnoreCase);

            // Creating the file with decoded text
            string decodedFile = "decoded_text.txt";
            File.WriteAllText(decodedFile, decodedText);
            Console.WriteLine($"Content of the {decodedFile} file:\n");
            Console.WriteLine($"{decodedText}\n");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
