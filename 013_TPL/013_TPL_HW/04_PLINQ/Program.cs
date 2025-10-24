/*
 * Створіть масив чисел розмірністю 1000000 або більше. Використовуючи генератор випадкових чисел, 
 * проініціалізуйте цей масив значеннями. 
 * Створіть PLINQ запит, який дозволить отримати усі непарні числа з вихідного масиву.
 */

namespace PLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[1000000];
            Random random = new Random();

            // Fill the array with random integers.
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-100, 101);
            }

            var oddNumbers = array.AsParallel().Where(element => element % 2 != 0);

            foreach (int element in oddNumbers)
                Console.Write(element + " ");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
