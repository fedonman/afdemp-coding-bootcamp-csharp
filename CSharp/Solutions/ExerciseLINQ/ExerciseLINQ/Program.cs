using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLINQ
{
	class Program
	{
        interface inter
        {
            int Age { get; set; }
        }

        class MyClass : inter
        {
            string Source { get; set; }
            public int aclass { get; set; }
            public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public MyClass()
            {

            }
        }

        class Student
		{
			public string Name { get; private set; }
			public int Age { get; private set; }

			public Student(string name, int age)
			{
				Name = name;
				Age = age;
			}
		}

		class Teacher
		{
			public string Name { get; private set; }
			public int Age { get; private set; }

			public Teacher(string name, int age)
			{
				Name = name;
				Age = age;
			}
		}

		class Course
		{
			public string Name; 
			public List<Student> Students { get; private set; }
			public List<Teacher> Teachers { get; private set; }

			public Course(string name)
			{
				Name = name;
				Students = new List<Student>();
				Teachers = new List<Teacher>();
			}
			
			public void AddStudent(params Student[] students)
			{
				foreach (Student student in students) {
					if (!Students.Contains(student)) {
						Students.Add(student);
					}
				}
			}

			public void AddTeacher(params Teacher[] teachers)
			{
				foreach (Teacher teacher in teachers) {
					if (!Teachers.Contains(teacher)) {
						Teachers.Add(teacher);
					}
				}
			}
		}

		class University
		{
			public string Name { get; private set; }
			public string ShortName { get; private set; }
			public List<Student> Students { get; private set; }
			public List<Teacher> Teachers { get; private set; }
			public List<Course> Courses { get; private set; }

			public University(string name, string shortname)
			{
				Name = name;
				ShortName = shortname;
				Students = new List<Student>();
				Teachers = new List<Teacher>();
				Courses = new List<Course>();
			}

			public void AddStudent(params Student[] students)
			{
				foreach (Student student in students) {
					if (!Students.Contains(student)) {
						Students.Add(student);
					}
				}
			}

			public void AddTeacher(params Teacher[] teachers)
			{
				foreach (Teacher teacher in teachers) {
					if (!Teachers.Contains(teacher)) {
						Teachers.Add(teacher);
					}
				}
			}

			public void AddCourse(params Course[] courses)
			{
				foreach (Course course in courses) {
					if (!Courses.Contains(course)) {
						Courses.Add(course);
					}
				}
			}
		}

		static void Main(string[] args)
		{
			University EMP = new University("Ethniko Metsoveio Polytexneio", "EMP");
			EMP.AddStudent(new Student[]
			{
				new Student("Nikos", 19),
				new Student("Katerina", 21),
				new Student("Takis", 25),
				new Student("Kostas", 32),
				new Student("Vasilis", 24),
				new Student("Maria", 18),
				new Student("Sara", 24),
				new Student("Iraklis", 26),
				new Student("Giannis", 30),
				new Student("Giorgos", 18),
				new Student("Giorgos", 20),
				new Student("Makis", 25),
				new Student("Ino", 30)
			});

            EMP.AddStudent(new Student("Nick", 30), new Student("Mike", 20));
            EMP.AddStudent(new Student("Tom", 30));

            EMP.AddTeacher(new Teacher[]
			{
				new Teacher("Kalogeropoulos", 52),
				new Teacher("Papaioannou", 49),
				new Teacher("Kogas", 70)
			});

			EMP.AddCourse(new Course[] {
				new Course("C#"),
				new Course("SQL"),
				new Course("HTML")
			});

			EMP.Courses[0].AddStudent(EMP.Students.GetRange(0, 5).ToArray());
			EMP.Courses[0].AddTeacher(EMP.Teachers.GetRange(0, 1).ToArray());
			EMP.Courses[1].AddStudent(EMP.Students.GetRange(4, 9).ToArray());
			EMP.Courses[1].AddTeacher(EMP.Teachers.GetRange(0, 2).ToArray());
			EMP.Courses[2].AddStudent(EMP.Students.GetRange(2, 3).ToArray());
			EMP.Courses[2].AddTeacher(EMP.Teachers.GetRange(1, 2).ToArray());

			//Find all Students with Age > 21 and print the results
			EMP.Students
				.FindAll(x => x.Age > 21)
				.ForEach(x => Console.WriteLine(x.Name));

			//List containing students ordered by their age.
			List<Student> studentsByAge = EMP.Students.OrderBy(x => x.Age).ToList();
			
			//Sample list with integers
			List<int> list = new List<int>() { 1, 2, -3, 4, 5, 6 };
			
			//Is every element of list greater than zero? Prints false			
			bool a = list.All(x => x > 0);
			Console.WriteLine(a);

			//Is any element of list greater than zero? Prints true			
			bool b = list.Any(x => x > 0);
			Console.WriteLine(b);

			//Get the min and max values.
			int max = list.Max();
			int min = list.Min();
			Console.WriteLine("min: " + min + ", max: " + max);

			//Computes the average of values
			double average = list.Average();
			Console.WriteLine("mean: " + average);

			Console.ReadKey();
		}
	}
}