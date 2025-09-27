/*
 * Створіть атрибут користувача AccessLevelAttribute, який дозволяє визначити рівень доступу 
 * користувача до системи. Сформуйте склад співробітників певної фірми як набору класів, 
 * наприклад, Manager, Programmer, Director. За допомогою атрибута AccessLevelAttribute 
 * розподіліть рівні доступу персоналу та відобразіть на екрані реакцію системи на спробу 
 * кожного співробітника отримати доступ до захищеної секції.
 */

using System.Reflection;

namespace AccessLevelAttribute
{
    internal class Program
    {
        private const int requiredLevel = 2;
        static void Main(string[] args)
        {
            var employees = new List<Employee>();
            employees.Add(new Programmer());
            employees.Add(new Manager());
            employees.Add(new Director());

            foreach (var employee in employees)
            { 
                CheckAccess(employee);
                Console.WriteLine();
            }

            // Delay
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void CheckAccess(Employee employee)
        {
            Type type = employee.GetType();
            var attribute = type.GetCustomAttribute<AccessLevelAttribute>();

            if (attribute == null)
            {
                Console.WriteLine($"{type.Name}: No access level defined. Access denied");
                return;
            }

            Console.WriteLine($"{type.Name} has access level {attribute.AccessLevel}");

            if (attribute.AccessLevel >= requiredLevel)
            {
                Console.WriteLine("Access granted");
            }
            else
            {
                Console.WriteLine("Access denied");
            }
        }
    }
}
