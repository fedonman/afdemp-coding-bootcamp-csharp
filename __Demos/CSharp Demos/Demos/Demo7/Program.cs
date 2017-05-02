using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo7
{
    public class Schedule
    {
        public string From { get; set; }
        public string To { get; set; }
    }
    /// <summary>
    /// Recursion
    /// </summary>
    public class Program
    {
        public static List<List<Schedule>> Solutions { get; set; }
        public static List<Schedule> Schedules { get; set; }
        public static void Main(string[] args)
        {
            Schedules = new List<Schedule>()
            {
                new Schedule(){From="A",To="B" },
                new Schedule(){From="C",To="D" },
                new Schedule(){From="B",To="D" },
                new Schedule(){From="A",To="C" },
                new Schedule(){From="A",To="E" },
                new Schedule(){From="E",To="C" },
                new Schedule(){From="E",To="D" },
                new Schedule(){From="D",To="A" }
            };

            String Start = Console.ReadLine();
            String Destination = Console.ReadLine();

            Solutions = new List<List<Schedule>>();
            CheckRoute("", Start, Destination, 3);

            Console.ReadKey();
            //CountingWithRecursion(0);
            //Console.ReadKey();
        }

        public static void CheckRoute(String CurrentRoute, String CurrentlyAt, String Destination, int stops)
        {
            Debug.WriteLine(stops);
            if (stops == 0)
               return;

            for (int i = 0; i < Schedules.Count; i++)
            {
                Schedule CurrentSchedule = Schedules[i];
                if (CurrentSchedule.From == CurrentlyAt)
                {
                    if (CurrentSchedule.To != Destination)
                    {
                        CheckRoute(CurrentRoute + $"{CurrentSchedule.From}->{CurrentSchedule.To} ", CurrentSchedule.To, Destination, --stops);
                    }
                    else
                    {
                        Console.WriteLine(CurrentRoute + $"{CurrentSchedule.From}->{CurrentSchedule.To} ");
                    }
                }
            }

            return;
        }

        public static void CountingWithIteration()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);
        }

        public static void CountingWithRecursion(int i)
        {
            Console.WriteLine(i);
            if (i < 9)
            {
                i = i + 1;
                CountingWithRecursion(i);
                return;
            }
            else
                return;
        }
    }

}
