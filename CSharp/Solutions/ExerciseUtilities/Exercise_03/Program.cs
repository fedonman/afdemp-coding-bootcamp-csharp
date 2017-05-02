using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseUtilities
{
    class Program
    {
        public static class Utilities
        {
            public static void Swap (ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            public static void Swap<T> (ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Utilities.Swap(ref a, ref b);
            Console.WriteLine(a);

            double x = 1.5;
            double y = 2;
            Utilities.Swap(ref x, ref y);
            Console.WriteLine(x);

            Console.ReadKey();
        }
    }
}
