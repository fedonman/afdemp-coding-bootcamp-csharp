using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        public struct CourseTime
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public class Course : IObservable<Course>
        {
            public string Name { get; set; }
            private DateTime startTime;
            private DateTime endTime;

            private List<IObserver<Course>> observers;

            public DateTime StartTime
            {
                get
                {
                    return startTime;
                }
                set
                {
                    startTime = value;
                    foreach (var observer in observers)
                    {
                        observer.OnNext(this);
                    }
                }
            }

            public DateTime EndTime
            {
                get
                {
                    return endTime;
                }
                set
                {
                    endTime = value;
                    foreach (var observer in observers)
                    {
                        observer.OnNext(this);
                    }
                }
            }

            public Course(string name)
            {
                Name = name;
                observers = new List<IObserver<Course>>();
            }

            public Course(string name, DateTime start, DateTime end)
            {
                Name = name;
                startTime = start;
                endTime = end;
                observers = new List<IObserver<Course>>();
            }

            public IDisposable Subscribe(IObserver<Course> observer)
            {
                if (!observers.Contains(observer))
                    observers.Add(observer);
                return new Unsubscriber(observers, observer);

            }

            public void Dismiss()
            {
                foreach (var observer in observers)
                    if (observers.Contains(observer))
                        observer.OnCompleted();

                observers.Clear();
            }

            private class Unsubscriber : IDisposable
            {
                private List<IObserver<Course>> _observers;
                private IObserver<Course> _observer;

                public Unsubscriber(List<IObserver<Course>> observers, IObserver<Course> observer)
                {
                    this._observers = observers;
                    this._observer = observer;
                }

                public void Dispose()
                {
                    if (_observer != null && _observers.Contains(_observer))
                        _observers.Remove(_observer);
                }
            }

        }

        public class Stakeholder : IObserver<Course>
        {
            protected IDisposable unsubscriber;
            protected string name;

            public virtual void Subscribe(IObservable<Course> course)
            {
                if (course != null)
                    unsubscriber = course.Subscribe(this);
            }

            public virtual void Unsubscribe()
            {
                unsubscriber.Dispose();
            }

            public void OnCompleted()
            {
                Console.Write(name + ": Course ended!");
            }

            public void OnError(Exception error)
            {
                Console.WriteLine(name + ": Error!");
            }

            public void OnNext(Course value)
            {
                Console.WriteLine(name + ": I got notified from course '" + value.Name + "'. Start Time: " + value.StartTime + ", End Time: " + value.EndTime);
            }
        }

        public class Student : Stakeholder
        {
            public Student(string name)
            {
                this.name = name;
            }
        }

        public class Teacher : Stakeholder
        {
            public Teacher(string name)
            {
                this.name = name;
            }
        }

        public class Organiser: Stakeholder
        {
            public Organiser(string name)
            {
                this.name = name;
            }
        }

        static void Main(string[] args)
        {
            Course c1 = new Course("Math 101", DateTime.Now, DateTime.Now.AddDays(10));
            Student s1 = new Student("Jim");
            Student s2 = new Student("Nicol");
            Teacher t1 = new Teacher("Mr Mad");
            c1.Subscribe(s1);
            c1.Subscribe(s2);
            
            c1.EndTime = c1.EndTime.AddMonths(1);

            Course c2 = new Course("Quantum Physics", DateTime.Now, DateTime.Now.AddDays(30));
            c2.Subscribe(s1);
            c2.Subscribe(t1);

            c2.EndTime = c2.EndTime.AddDays(2);
            c1.EndTime = c1.EndTime.AddMonths(1);

            Console.ReadKey();
        }

    }
}
