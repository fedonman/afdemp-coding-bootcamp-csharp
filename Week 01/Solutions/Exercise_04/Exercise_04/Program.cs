using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04
{
    class Program
    {
        //Inheritance can run deep
        public class World
        {

        }
        public class Human : World
        {

        }
        //Students inherits from Human, but also implements the IComparable interface
        public class Student : Human, IComparable<Student>
        {
            public string Name;
            public double Mark;

            //Constructor
            public Student(string name, double mark)
            {
                Name = name;
                Mark = mark;
            }

            //We are obliged to implement this function since Student implements
            //the IComparable interface.
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
            //List of Students
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

            //Sort the list. 
            //It will be sorted according to our implementation of CompareTo.
            list.Sort();

            foreach (Student s in list)
            {
                Console.WriteLine(s.Name + " got " + s.Mark);
            }
            Console.ReadKey();
        }
    }
}

