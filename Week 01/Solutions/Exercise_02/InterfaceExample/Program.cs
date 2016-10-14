using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class Program
    {
        public class World
        {

        }
        public class Human : World
        {

        }
        public class Student : Human, IComparable<Student>
        {
            public string Name;
            public double Mark;

            public Student(string name, double mark)
            {
                Name = name;
                Mark = mark;
            }

            public int CompareTo(Student s)
            {
                if (this.Mark < s.Mark)
                {
                    return -1;
                }
                else if (this.Mark > s.Mark)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        static void Main(string[] args)
        {
            List<Student> list = new List<Student>
            {
                new Student("Nick", 5.2),
                new Student("Bob", 2.5),
                new Student("Helen", 10),
                new Student("Steve", 7.4)
            };
            foreach (Student s in list)
            {
                Console.WriteLine(s.Name + " got " + s.Mark);
            }
            Console.WriteLine();
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine(s.Name + " got " + s.Mark);
            }
            Console.ReadKey();
        }
    }
}
