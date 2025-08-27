/*
 * Створіть колекцію, яка б за своєю структурою нагадувала «родове дерево» 
 * (ім'я людини, рік народження), причому до неї можна додавати/вилучати нового родича, 
 * є можливість побачити всіх спадкоємців обраної людини, відібрати родичів за роком народження. 
 */

namespace FamilyTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamilyTree familyTree = new FamilyTree();

            Person grandfather = familyTree.AddPerson("John Smith", 1950);
            Person father = familyTree.AddPerson("Jack Smith", 1971, grandfather);
            Person uncle = familyTree.AddPerson("Michael Smith", 1972, grandfather);
            Person aunt = familyTree.AddPerson("Mary Gordon", 1974, grandfather);
            Person person = familyTree.AddPerson("Peter Smith", 1991, father);
            Person brother = familyTree.AddPerson("Colin Smith", 1993, father);
            Person sister = familyTree.AddPerson("Ann Shelly", 1994, father);
            Person cousin1 = familyTree.AddPerson("Nick Smith", 1994, uncle);
            Person cousin2 = familyTree.AddPerson("John Smith", 1995, uncle);
            Person cousin3 = familyTree.AddPerson("Ann Gordon", 1995, aunt);
            Person son = familyTree.AddPerson("Jack Smith", 2012, person);
            Person daughter = familyTree.AddPerson("Mary Smith", 2015, person);
            Person nephew1 = familyTree.AddPerson("Lionel Smith", 2014, brother);
            Person niece1 = familyTree.AddPerson("Lynn Smith", 2016, brother);
            Person nephew2 = familyTree.AddPerson("Patrick Shelly", 2016, sister);
            Person niece2 = familyTree.AddPerson("Samantha Shelly", 2018, sister);

            // Print whole tree
            Console.WriteLine("The whole family tree:");
            familyTree.PrintTree(grandfather);
            Console.WriteLine();

            // Print list of person's descendants
            Console.WriteLine($"The list of descendants of {person}");
            foreach (var item in familyTree.GetDescendants(person))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Print list of people of 1996 year of birth
            Console.WriteLine("The list of people who were born in 2016");
            foreach (var item in familyTree.FilterByYear(2016))
            {  
                Console.WriteLine(item); 
            }
            Console.WriteLine();

            // Deleting aunt an her descendants
            familyTree.RemovePerson(aunt);

            // Print whole tree after deleting aunt and her descendants
            Console.WriteLine("The whole family tree after aunt and her descendants deleting:");
            familyTree.PrintTree(grandfather);
            Console.WriteLine();

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
