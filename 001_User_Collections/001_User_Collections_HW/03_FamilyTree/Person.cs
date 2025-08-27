using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    internal class Person
    {
        public string Name { get; }
        public int YearOfBirth { get; }
        public List<Person> Children { get; }

        public Person (string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Children = new List<Person> ();
        }

        public override string ToString()
        {
            return $"{Name} ({YearOfBirth})";
        }
    }
}
