/*
 * Створіть колекцію, в яку можна записувати два значення одного слова, 
 * на кшталт російсько-англо-українського словника. 
 * І в ній можна для українського слова знайти або лише російське значення, 
 * або лише англійське та вивести його на екран. 
 */

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyDictionary myDictionary = new MyDictionary();

            myDictionary.Add("  вітер  ", "ветер", "wind");
            myDictionary.Add("Яблуко", "  яблоко  ", "Apple");
            myDictionary.Add("стеля", "Потолок", "  ceiling  ");
            myDictionary.Add("Стіна", "  стена", "  wall");

            Console.WriteLine($"вітер: {myDictionary.GetTranslation("Вітер  ", TranlationLanguage.Russian)}");
            Console.WriteLine($"яблуко: {myDictionary.GetTranslation("   яблуко", TranlationLanguage.English)}");
            Console.WriteLine($"стеля: {myDictionary.GetTranslation("    Стеля  ", TranlationLanguage.Russian)}");
            Console.WriteLine($"стіна: {myDictionary.GetTranslation("стіна  ", TranlationLanguage.English)}");

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
