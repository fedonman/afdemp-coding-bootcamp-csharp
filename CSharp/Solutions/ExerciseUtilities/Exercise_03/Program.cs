using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseUtilities
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // 1. a)
            int a = 5;
            int b = 10;
            Utilities.Swap(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");

            // 1. b)
            string x = "xxx";
            string z = "zzz";
            Utilities.Swap(ref x, ref z);
            Console.WriteLine($"x: {x}, z: {z}");

            // 2. a)
            List<int> listA = new List<int>() { 1, 5, 5, 3, 4, 4, 4, 4, 6, 6, 6, 6 };
            List<int> resultA = Utilities.Subsequence(listA);

            Console.Write("Subsequence of integers: ");
            foreach(int i in resultA)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();

            // 2. bonus)
            List<int> resultA1 = Utilities.SubLINQ(listA);
            Console.Write("Subsequence of integers using LINQ: ");
            foreach (int i in resultA1)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();

            // 2. b)
            List<Fraction> listB = new List<Fraction>()
            {
                new Fraction(3, 5),
                new Fraction(3, 5),
                new Fraction(3, 5),
                new Fraction(4, 7),
                new Fraction(1, 2),
                new Fraction(1, 2),
                new Fraction(3, 5),
                new Fraction(4, 5)
            };
            List<Fraction> resultB = Utilities.Subsequence(listB);
            Console.Write("Subsequence of fractions: ");
            foreach (Fraction f in resultB)
            {
                Console.Write(f + ", ");
            }
            Console.WriteLine();

            // 2. c)
            List<Fraction> resultB1 = listB.GetSubsequence();
            Console.Write("Subsequence of fractions as extension method: ");
            foreach (Fraction f in resultB1)
            {
                Console.Write(f + ", ");
            }
            Console.WriteLine();

            /* dynamic variables */
            int test1 = Utilities.Test(5);
            Fraction test2 = Utilities.Test(100);
            dynamic test3 = Utilities.Test(10);
            Console.WriteLine(test3 is Fraction);


            Console.WriteLine(test1);
            Console.WriteLine(test2);

            dynamic root1;
            dynamic root2;
            // real result
            Type type1 = Utilities.QuadraticSolve(2, 0, 2, out root1, out root2);
            Console.WriteLine(root1 + "  " + root2 + "  " + type1); 

            // complex result
            Type type2 = Utilities.QuadraticSolve(2, 2, 2, out root1, out root2);
            Console.WriteLine(root1 + "  " + root2 + "  " + type2);

            /* Reflection
            foreach (System.Reflection.MemberInfo f in type2.GetMembers())
            {
                Console.WriteLine(f.Name);
            }
            */

            // i don't need to store the returned type
            Utilities.QuadraticSolve(4, 6, 2, out root1, out root2);
            Console.WriteLine(root1 + "  " + root2);

            Console.ReadKey();
        }
    }
}