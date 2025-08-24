/*
 * Створіть колекцію, в якій зберігалися б найменування 12 місяців, 
 * порядковий номер і кількість днів у відповідному місяці. 
 * Реалізуйте можливість вибору місяців як за порядковим номером, так і кількістю днів у місяці, 
 * при цьому результатом може бути не тільки один місяць.
 */

namespace Months
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonthColllection year = new MonthColllection();

            // Selecting a month by its ordinal number
            Console.WriteLine("Enter ordinal number of month (1-12): ");
            if ((!int.TryParse(Console.ReadLine(), out int number)) || (number < 1 || number > 12))
            {
                Console.WriteLine("Wrong input for ordinal number of month");
                return;
            }

            Console.WriteLine(year.GetMonthByNumber(number));



            // Selecting months by number of days
            int[] numberOfDays = { 28, 30, 31 };
            Console.WriteLine("Enter number of days in month (28, 30, or 31): ");
            if ((!int.TryParse(Console.ReadLine(), out int days)) || (!(numberOfDays.Contains(days))))
            {
                Console.WriteLine("Wrong input for number of days in month");
                return;
            }

            foreach (var item in year.GetMonthsByDays(days))
            {
                Console.WriteLine(item);
            }

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
