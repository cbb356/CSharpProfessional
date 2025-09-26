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
            obsoleteMethods.OldMethod();
            //obsoleteMethods.VeryOldMethod();    // Compilation error

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    internal class ObsoleteMethods
    {
        [Obsolete("This method is deprecated but you can use it")]
        public void OldMethod()
        {
            Console.WriteLine("OldMethod calling");
        }

        [Obsolete("This method is deprecated and you can't use it", true)]
        public void VeryOldMethod()
        {
            Console.WriteLine("VeryOldMethod calling");
        }
    }
}
