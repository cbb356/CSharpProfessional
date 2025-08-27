using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    internal class FamilyTree
    {
        private List<Person> _family = new List<Person>();
        public Person AddPerson(string name, int yearOfBirth, Person? parent = null) 
        {
            Person person = new Person(name, yearOfBirth);
            if (parent != null)
            {
                parent.Children.Add(person);
            }
            _family.Add(person);
            return person;
        }

        public void RemovePerson(Person person)
        {
            // Remove from parent's children list
            foreach (var p in _family)
            {
                p.Children.Remove(person);
            }
            // Remove recursively from collection
            RemoveRecursively(person);
        }

        private void RemoveRecursively(Person person)
        {
            foreach (var child in person.Children.ToList())
            {
                RemoveRecursively(child);
            }
            _family.Remove(person);
        }

        public Person? FindPerson(string name, int yearOfBirth)
        {
            return _family.FirstOrDefault(p => p.Name == name && p.YearOfBirth == yearOfBirth);
        }

        public List<Person> GetDescendants(Person person)
        {
            var descendants = new List<Person>();
            CollectDescendants(person, descendants);
            return descendants;
        }

        private void CollectDescendants(Person person, List<Person> list)
        {
            foreach (var child in person.Children)
            {
                list.Add(child);
                CollectDescendants(child, list);
            }
        }

        public List<Person> FilterByYear(int year)
        {
            return _family.Where(p => p.YearOfBirth == year).ToList();
        }

        // Print the list of descendants
        public void PrintTree(Person root, string indent = "")
        {
            Console.WriteLine(indent + root);
            foreach (var child in root.Children)
            {
                PrintTree(child, indent + "   ");
            }
        }
    }
}
