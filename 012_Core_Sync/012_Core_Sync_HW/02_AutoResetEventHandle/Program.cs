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

            while (true)
            {
                Console.WriteLine("Press key to choose action: S - signal, Q - exit");
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();

                switch (operation)
                {
                    case "S":
                        handle.Set();
                        Console.WriteLine("The signal has been sent.");
                        break;
                    case "Q":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.Write("Wrong input. ");
                        break;
                }
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
