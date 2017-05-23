using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_University
{
    class Program
    {
        static void Main(string[] args)
        {
            University uni = new University();

            // Register some students
            if (uni.IsReachedLimit(uni.students[0]) == false)
                uni.RegisterToCourse(uni.students[0], uni.courses[0]);
            if (uni.IsReachedLimit(uni.students[0]) == false)
                uni.RegisterToCourse(uni.students[0], uni.courses[2]);
            if (uni.IsReachedLimit(uni.students[0]) == false)
                uni.RegisterToCourse(uni.students[0], uni.courses[5]);
            if (uni.IsReachedLimit(uni.students[0]) == false)
                uni.RegisterToCourse(uni.students[0], uni.courses[6]);

            if (uni.IsReachedLimit(uni.students[1]) == false)
                uni.RegisterToCourse(uni.students[1], uni.courses[1]);
            if (uni.IsReachedLimit(uni.students[1]) == false)
                uni.RegisterToCourse(uni.students[1], uni.courses[3]);
            if (uni.IsReachedLimit(uni.students[1]) == false)
                uni.RegisterToCourse(uni.students[1], uni.courses[4]);
            if (uni.IsReachedLimit(uni.students[1]) == false)
                uni.RegisterToCourse(uni.students[1], uni.courses[9]);

            //Register grades;
            uni.CourseGrade(uni.students[0], uni.courses[0],5);
            uni.CourseGrade(uni.students[0], uni.courses[2], 6.5);
            uni.CourseGrade(uni.students[0], uni.courses[5], 8);
            uni.CourseGrade(uni.students[0], uni.courses[6], 2);

            uni.CourseGrade(uni.students[1], uni.courses[1], 3.5);
            uni.CourseGrade(uni.students[1], uni.courses[3], 6.5);
            uni.CourseGrade(uni.students[1], uni.courses[4], 10);
            uni.CourseGrade(uni.students[1], uni.courses[9], 1);

            //Register complete courses if grade >=5 for some student
            uni.RegisterCompletedCourses(uni.students[0]);
            uni.RegisterCompletedCourses(uni.students[1]);

            //Find median grade for student 0 and student 1
            double student0grade = uni.MedianGrade(uni.students[0]);
            double student1grade = uni.MedianGrade(uni.students[1]);

            Console.WriteLine(uni.students[0].StudentName + " : " + student0grade);
            Console.WriteLine(uni.students[1].StudentName + " : " + student1grade);
            Console.WriteLine("\n\n\n");

            //List of students from best to worst
            Student[] studentclassific = uni.StudentClassification();

            foreach (Student student in studentclassific)
            {
                Console.WriteLine(student.StudentName + "\n");
            }

            Console.ReadKey();
        }
    }
}
