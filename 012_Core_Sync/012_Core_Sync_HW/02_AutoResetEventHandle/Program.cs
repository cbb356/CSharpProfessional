/*
 * Перетворіть приклад блокування подій таким чином, 
 * щоб замість ручної обробки використовувалася автоматична.
 */

using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoResetEventHandle
{
    internal class Program
    {
        static EventWaitHandle handle = null;

        static void Main(string[] args)
        {
            handle = new EventWaitHandle(false, EventResetMode.AutoReset, "GlobalEvent::GUID");

            Thread thread = new Thread(Function) { IsBackground = true };
            thread.Start();

            Console.WriteLine("\nPress any key to send signal");
            while (true)
            {
                Console.ReadKey();
                handle.Set();
                Console.WriteLine("The signal has been sent. Press any key to send another one");
            }
        }

        static void Function()
        {
            handle.WaitOne();

            while (true)
            {
                Console.WriteLine("Hello world!");
                Thread.Sleep(300);
            }
        }
    }
}
