/*
 * Напишіть консольну програму, яка дозволяє користувачеві зареєструватися під «Логіном», 
 * що складається тільки з символів латинського алфавіту, і пароля, що складається з цифр і символів.
 */

using System.Text.RegularExpressions;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? login, password;

            while (true)
            {
                Console.WriteLine("Enter login (Latin alphabet characters only):");
                login = Console.ReadLine()?.Trim() ?? string.Empty;
                if (Regex.IsMatch(login, @"^[a-zA-Z]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid login. Use only Latin letters");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter password (Latin alphabet characters and digits only):");
                password = Console.ReadLine()?.Trim() ?? string.Empty;
                if (Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid password. Use only Latin letters and digits");
                }
            }

            Console.WriteLine($"\nLogin: {login}");
            Console.WriteLine($"Password: {password}");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
