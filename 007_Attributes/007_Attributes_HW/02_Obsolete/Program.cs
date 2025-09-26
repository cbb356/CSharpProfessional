/*
 * Створіть клас і застосуйте до його методів атрибут Obsolete спочатку у формі, 
 * що просто виводить попередження, а потім у формі, що перешкоджає компіляції. 
 * Продемонструйте роботу атрибута з прикладу виклику даних методів.
 */

namespace Obsolete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obsoleteMethods = new ObsoleteMethods();
            obsoleteMethods.OldMethod();            // Warning: The method is deprecated
            //obsoleteMethods.VeryOldMethod();      // Error: The method is no longer supported

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
