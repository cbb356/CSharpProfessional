/*
 * Напишіть програму, яка дозволила б за вказаною адресою web-сторінки вибирати всі посилання 
 * на інші сторінки, номери телефонів, поштові адреси та зберігала отриманий результат у файл.
 */

using System;
using System.Text.RegularExpressions;

namespace WebSiteAnalizer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string siteURL = @"https://automationteststore.com/";

            try
            {
                using HttpClient client = new HttpClient();
                string html = await client.GetStringAsync(siteURL);

                // Regex patterns
                var linkRegex = new Regex(@"a href\s*=\s*[""'](?<url>https?://[^""'#\s>]+)[""']", RegexOptions.IgnoreCase);
                //var linkRegex = new Regex(@"href='(?<link>\S+)'>(?<text>\S+)</a>", RegexOptions.IgnoreCase);
                var emailRegex = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", RegexOptions.IgnoreCase);
                var phoneRegex = new Regex(@"(\+?\d{1,3})\s*(\(?\d{2,4}\)?\s*)?[\d\s-]{6,10}", RegexOptions.IgnoreCase);
                //var phoneRegex = new Regex(@"\+?[0-9][0-9\-\s().]{7,}[0-9]", RegexOptions.IgnoreCase);
                //var phoneRegex = new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", RegexOptions.IgnoreCase);

                // Extract matches
                var links = linkRegex.Matches(html);
                var emails = emailRegex.Matches(html);
                var phones = phoneRegex.Matches(html);

                //string htmlFile = "sample.html";
                //using StreamWriter htmlWriter = new StreamWriter(htmlFile);
                //htmlWriter.WriteLine(html);

                string resultFile = "extracted_data.txt";
                using StreamWriter writer = new StreamWriter(resultFile);

                writer.WriteLine($"Extracted Data from {siteURL}:\n");

                writer.WriteLine("Links:");
                foreach (Match m in links)
                    writer.WriteLine(m.Groups["url"].Value);
                writer.WriteLine();

                writer.WriteLine("Emails:");
                foreach (Match m in emails)
                    writer.WriteLine(m.Value);
                writer.WriteLine();

                writer.WriteLine("Phone Numbers:");
                foreach (Match m in phones)
                    writer.WriteLine(m.Value);
                writer.WriteLine();

                Console.WriteLine($"Extraction completed. Results saved to {resultFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
