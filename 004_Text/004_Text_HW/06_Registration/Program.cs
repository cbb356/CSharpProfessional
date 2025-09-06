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
            string? login, password, input = string.Empty;
            string loginPattern = @"^[a-zA-Z]+$";
            string passwordPattern = @"^[a-zA-Z0-9]+$";
            Regex regexLogin = new Regex(loginPattern);
            Regex regexPassword = new Regex(passwordPattern);

            while (!regexLogin.IsMatch(input ?? string.Empty))
            {
                Console.WriteLine("Create the login (only latin letters):");
                input = Console.ReadLine();
            }
            login = input;

            input = String.Empty;
            while (!regexPassword.IsMatch(input ?? string.Empty))
            {
                Console.WriteLine("Create the password (only latin letters and numbers):");
                input = Console.ReadLine();
            }
            password = input;

            Console.WriteLine($"Login: {login}");
            Console.WriteLine($"Password: {password}");

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
