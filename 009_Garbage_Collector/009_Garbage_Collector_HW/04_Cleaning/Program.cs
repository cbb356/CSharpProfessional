/*
 * Створіть власний клас, об’єкти котрого будуть займати багато місця в пам’яті (наприклад, в коді 
 * класу  буде  присутній  великий  масив)  і  реалізуйте  для  цього  класу  формалізований  шаблон 
 * очищення.  
 */

namespace Cleaning
{
    internal class Program
    {
        internal static void CreateInstance()
        {
            using (LargeObject largeObject = new LargeObject(50))
            {
                largeObject.DoWork();
            }
        }

        static void Main(string[] args)
        {
            CreateInstance();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
