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
            Console.WriteLine($"a: {a}, b: {b}");

            string x = "xxx";
            string z = "zzz";
            Utilities.Swap(ref x, ref z);
            Console.WriteLine($"x: {x}, z: {z}");

            Console.ReadKey();
        }
    }
}