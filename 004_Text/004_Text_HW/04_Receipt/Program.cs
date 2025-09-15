/*
 * Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» 
 * з певною кількістю найменувань товарів та датою здійснення покупки. 
 * Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.
 */

using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Receipt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; 
            
            // Creating the receipt
            string receiptFile = "receipt.txt";
            var builder = new StringBuilder();
            builder.AppendLine("Товар 1 – 79.50 грн."). 
            AppendLine("Товар 2 – 119.99 грн.").
            AppendLine("Товар 3 – 57.80 грн.").
            AppendLine("15-09-2025 14:32:15");
            string receiptText = builder.ToString();
            File.WriteAllText(receiptFile, receiptText);

            Console.WriteLine($"Receipt saved to {receiptFile}\n");
            Console.WriteLine("Original text of receipt");
            Console.WriteLine(receiptText);

            // Reading the receipt
            string[] receiptTextParced = File.ReadAllLines(receiptFile);

            // Printing receipt in current culture
            Console.WriteLine("Receipt in Current Locale");
            DisplayReceipt(receiptTextParced, CultureInfo.CurrentCulture);

            // Printing receipt in en-US culture
            Console.WriteLine();
            Console.WriteLine("Receipt in en-US Locale");
            DisplayReceipt(receiptTextParced, new CultureInfo("en-US"));

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DisplayReceipt(string[] lines, CultureInfo culture)
        {
            Regex itemRegex = new Regex(@"^(?<name>.+?)\s*[–-]\s*(?<price>\d+(?:[.,]\d{1,2})?)\s*грн\.?.$", RegexOptions.IgnoreCase);
            Regex dateRegex = new Regex(@"^(?<date>\d{2}-.+)$");

            foreach (var item in lines)
            {
                Match itemMatch = itemRegex.Match(item);
                if (itemMatch.Success)
                {
                    string name = itemMatch.Groups["name"].Value;
                    string priceString = itemMatch.Groups["price"].Value;

                    if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                    {
                        Console.WriteLine($"{name} - {price.ToString("C", culture)}");
                        continue;
                    }
                }

                Match dateMatch = dateRegex.Match(item);
                if (dateMatch.Success)
                {
                    string dateString = dateMatch.Groups["date"].Value;
                    if (DateTime.TryParse(dateString, out DateTime date))
                    {
                        Console.WriteLine($"{date.ToString(culture)}");
                        continue;
                    }
                }
            }

        }
    }
}
