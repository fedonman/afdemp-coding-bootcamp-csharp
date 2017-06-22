using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course("C# Basics", DateTime.Now, DateTime.Now.AddMonths(1));
            Student student = new Student("Bill");
            Instructor instructor = new Instructor("John");
            Organizer organizer = new Organizer("Mary");

            course1.Subscribe(student);
            course1.Subscribe(instructor);

            course1.EndTime = DateTime.Now.AddMonths(1);

            Console.WriteLine("---");

            course1.Unsubsribe(student);
            course1.EndTime = DateTime.Now.AddMonths(1);

            Console.ReadKey();
        }
    }
}
