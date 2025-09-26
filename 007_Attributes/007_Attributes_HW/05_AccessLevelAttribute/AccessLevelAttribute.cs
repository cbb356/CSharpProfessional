using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevelAttribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal class AccessLevelAttribute : Attribute
    {
        public int AccessLevel {  get; }
        public AccessLevelAttribute(int level) 
        { 
            AccessLevel = level;
        }
    }
}
