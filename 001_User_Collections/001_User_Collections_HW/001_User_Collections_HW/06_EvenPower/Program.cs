/*
 * Створіть метод, який як аргумент приймає масив цілих чисел і 
 * повертає колекцію квадратів усіх непарних чисел масиву. 
 * Для формування колекції використовуйте оператор yield.
 */

namespace EvenPower
{
    internal class Program
    {
        public static IEnumerable<int> EvenPowerNumbers(IEnumerable<int> source, Func<int, bool> condition)
        {
            foreach (var item in source)
            {
                if (condition(item))
                {
                    yield return (item * item);
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = EvenPowerNumbers(list, x => x % 2 == 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }
    }
}
