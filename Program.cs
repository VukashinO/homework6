using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    class Program
    {
        
        static void Main(string[] args)
        {



            var students = new List<Student>();
            var averagesName = new List<int>();
            var averagesLastName = new List<int>();

            while (true)
            {
                Console.Clear();
                string name;
                bool check;
                (name, check) = ReadNameConsole("enter student Name:");
                if (!check)
                {
                    Console.WriteLine($"you have entered invalid name format, please try again");
                    return;
                }
                string lastName;

                (lastName, check) = ReadLastNameConsole("enter student last Name:");
                if(!check)
                {
                    Console.WriteLine($"you have entered invalid last Name format, please try again");
                    return;
                }

                string grp;

                (grp, check) = ReadGroupConsole("enter student group:");
                if (!check)
                {
                    Console.WriteLine($"you have entered invalid group format, please try again");
                    return;
                }

                int age;

                (age, check) = ReadAgeConsole("enter student Age:");
                if(!check)
                {
                    Console.WriteLine("you have entered invalid intiger, please enter valid integer.");
                    return;
                }

                students.Add(new Student { FirstName = name, LastName = lastName, Group = grp, Age = age });

                Console.WriteLine("enter new Student Y/n");
                if(Console.ReadLine() == "n")
                {
                    break;
                }
            }

            string shorstestName;
            int shorstestNameLength;
            (shorstestName, shorstestNameLength) = findShortestName(students);


            string longestName;
            int longestNameLength;
            (longestName, longestNameLength) = findLongestName(students);

            string youngestName;
            int youngestAge;
            (youngestName, youngestAge) = findYoungest(students);

            string oldestName;
            int oldestAge;
            (oldestName, oldestAge) = findOldest(students);

            double averageYears;
            averageYears = findAverageYears(students);

            foreach (var student in students)
            {
                averagesName.Add(student.GetNameLength());
            }
            foreach (var student in students)
            {
                averagesLastName.Add(student.GetLastNameLength());
            }

            double averageName = averagesName.Average();
            double averageLastName = averagesLastName.Average();

         
            
            Console.WriteLine($"student with shortest name in g4 is: {shorstestName} with {shorstestNameLength} characters");
            Console.WriteLine($"student with longest name in g4 is: {longestName} with {longestNameLength} characters");
            Console.WriteLine($"youngest student in g4 is: {youngestName} with {youngestAge} years.");
            Console.WriteLine($"oldest student in g4 is: {oldestName} with {oldestAge} years.");
            Console.WriteLine($"group4 average length name is: {averageName} characters.");
            Console.WriteLine($"group4 average length Last Name is: {averageLastName} characters.");
            Console.WriteLine($"average years in g4 is: {averageYears} years.");
        }

          // Check Validation For Name:


        public static (string, bool) ReadNameConsole(string message = "")
        {
            if(!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
              
            }
            var name = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(name))
            {
                return ("x0", false);
            }
            return (name, true);

            
            
        }
        // Check Validation For Last Name:

        public static (string, bool) ReadLastNameConsole(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);

            }
            var lastName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(lastName))
            {
                return ("x0", false);
            }
            return (lastName, true);



        }

        // check validation for Group:


        public static (string, bool) ReadGroupConsole(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);

            }
            var grp = Console.ReadLine().ToLower();
            
            if (String.IsNullOrWhiteSpace(grp) || grp.Length > 2)
            {
                return ("x0", false);
            }
            return (grp, true);



        }


        // Check Validation for Age:


        public static (int, bool) ReadAgeConsole(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);

            }
            var grp = Console.ReadLine();
            int result;
            bool isNum = int.TryParse(grp, out result);
            if(!isNum)
            {
                return (0, false);
            }

            return (result, true);



        }
        // Find shortest Name Length:
        public static (string, int) findShortestName(List<Student>students)
        {
            students.Sort((x, y) => Comparer<int>.Default.Compare(x.GetNameLength(), y.GetNameLength()));

            return (students[0].FirstName, students[0].GetNameLength());
        }
        // Find longest Name Length:
        public static (string, int) findLongestName(List<Student> students)
        {
           
            students.Sort((x, y) => Comparer<int>.Default.Compare(x.GetNameLength(), y.GetNameLength()));
            students.Reverse();
            return (students[0].FirstName, students[0].GetNameLength());
        }

        // Find youngest Age student:

        public static (string, int) findYoungest(List<Student>students)
        {

            students.Sort((x, y) => Comparer<int>.Default.Compare(x.Age, y.Age));
            return (students[0].FirstName, students[0].Age);
        }

        // Find Oldest student:

        public static (string, int) findOldest(List<Student>students)
        {
            students.Sort((x, y) => Comparer<int>.Default.Compare(x.Age, y.Age));
            students.Reverse();
            return (students[0].FirstName, students[0].Age);
        }

        // find Average years:

        public static double findAverageYears(List<Student>students)
        {
            double average = 0;
            foreach (var student in students)
            {
                average += student.Age;
            }
            return (average / students.Count);
        }
    }
}
