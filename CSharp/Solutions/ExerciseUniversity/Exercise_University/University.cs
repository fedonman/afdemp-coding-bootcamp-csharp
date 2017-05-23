using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_University
{
    class University
    {
        public List<Course> courses;
        public List<Student> students;

        public bool[,] IsRegistered;
        public double[,] Grades;
        public double[,] CompletedCourses;

        public University()
        {
            courses = new List<Course>()
            {
                new Course("Applied Mathematics I",5),
                new Course("Computer Programming and Applications",4),
                new Course("Engineering Mechanics - Statics",5),
                new Course("Physics",3),
                new Course("Technical Drawing and CAD",4),
                new Course("Foreign Language",3),
                new Course("Applied Mathematics II",5),
                new Course("Probability - Statistics",3),
                new Course("Introduction to the Mechanics of Materials",4),
                new Course("Geology for Civil Engineers",3),
                new Course("Construction Technology I",4)
            };

            students = new List<Student>()
            {
                new Student("George Washington"),
                new Student("John Adams"),
                new Student("Thomas Jefferson"),
                new Student("James Madison"),
                new Student("James Monroe"),
                new Student("John Quincy Adams"),
                new Student("Andrew Jackson"),
                new Student("Martin Van Buren"),
                new Student("William Henry Harrison"),
                new Student("John Tyler")
            };

            IsRegistered = new bool[students.Count, courses.Count];
            Grades = new double[students.Count, courses.Count];
            CompletedCourses = new double[students.Count, courses.Count];

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    IsRegistered[i, j] = false;
                    Grades[i, j] = 0.0;
                    CompletedCourses[i, j] = 0.0;
                }
            }
        }

        public void RegisterToCourse(Student student, Course course)
        {
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    if (students[i] == student && courses[j] ==  course && IsRegistered[i, j] == false)
                    {
                        IsRegistered[i, j] = true;
                    }
                }
            }
        }
                
        public void CourseGrade(Student student, Course course , double grade)
        {
            
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    if (students[i] == student && courses[j] == course && IsRegistered[i, j] == true)
                    {
                        Grades[i, j] = grade;
                    }
                }
            }

        }

        public bool IsReachedLimit(Student student)
        {
            int count = 0;
            int position = students.IndexOf(student);
            for (int i = 0; i < courses.Count; i++)
            {
                if (IsRegistered[position, i] == true)
                {
                    count++;
                }
            }

            if (count < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RegisterCompletedCourses(Student student)
        {
            int studentposition = students.IndexOf(student);

            for (int i = 0; i < courses.Count; i++)
            {
                if (Grades[studentposition,i] >= 5)
                {
                    CompletedCourses[studentposition, i] = Grades[studentposition, i];
                }
            }
        }

        public double MedianGrade(Student student)
        {
            int studentposition = students.IndexOf(student);
            double MedianNumerator = 0;
            double MedianDenominator = 0;

            for (int i = 0; i < courses.Count; i++)
            {
                if (CompletedCourses[studentposition, i] >= 5)
                {
                    MedianNumerator += CompletedCourses[studentposition, i] * Convert.ToDouble(courses[i].Ects);
                    MedianDenominator += Convert.ToDouble(courses[i].Ects);
                }
            }

            return MedianNumerator / MedianDenominator;
        }

        public Student[] StudentClassification()
        {
            Student[] studentclassificationarray = new Student[students.Count];
            double[] mediangradesarray = new double[students.Count];
            int[] values = new int[students.Count];


            for (int i = 0; i < students.Count; i++)
            {
                mediangradesarray[i] = MedianGrade(students[i]);
                values[i] = i;
            }

            Array.Sort(mediangradesarray, values);

            for (int i = 0; i < students.Count; i++)
            {
                studentclassificationarray[i] = students[values[i]];
            }

            Array.Reverse(studentclassificationarray);

            return studentclassificationarray;
        }
    }
}
