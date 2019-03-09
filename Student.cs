using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
   public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public int Age { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int GetNameLength()
        {
            var length = FirstName.Length;
            return length;
        }
        public int GetLastNameLength()
        {
            var length = LastName.Length;
            return length;
        }
    }
}
