using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevelAttribute
{
    internal class Employee
    {

    }

    [AccessLevel(1)]
    internal class Programmer : Employee 
    {
    
    }

    [AccessLevel(2)]
    internal class Manager : Employee
    {

    }

    [AccessLevel(3)]
    internal class Director : Employee
    {

    }
}
