using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseUtilities
{
    public static class Utilities
    {
        // 1. a) Swap integers
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // 1. b) Swap generics
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // 2. a) Maximum Subsequence of integers
        public static List<int> Subsequence(List<int> list)
        {
            int startIndex = 0;
            int count = 1;
            int maxCount = 0;
            int maxStartIndex = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] == list[i])
                {
                    count++;
                    if (i == list.Count - 1 && count > maxCount)
                    {
                        maxStartIndex = startIndex;
                        maxCount = count;
                    }
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxStartIndex = startIndex;
                    }
                    startIndex = i;
                    count = 1;
                }
            }
            return list.GetRange(maxStartIndex, maxCount);
        }


        public static List<T> Subsequence<T>(List<T> list)
        {
            int startIndex = 0;
            int count = 1;
            int maxCount = 0;
            int maxStartIndex = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1].Equals(list[i]))
                {
                    count++;
                    if (i == list.Count - 1 && count > maxCount)
                    {
                        maxStartIndex = startIndex;
                        maxCount = count;
                    }
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxStartIndex = startIndex;
                    }
                    startIndex = i;
                    count = 1;
                }
            }
            return list.GetRange(maxStartIndex, maxCount);
        }

        // 2. c) Maximum Subsequence of Generic type as extention method
        public static List<T> GetSubsequence<T>(this List<T> list)
        {
            int startIndex = 0;
            int count = 1;
            int maxCount = 0;
            int maxStartIndex = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1].Equals(list[i]))
                {
                    count++;
                    if (i == list.Count - 1 && count > maxCount)
                    {
                        maxStartIndex = startIndex;
                        maxCount = count;
                    }
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxStartIndex = startIndex;
                    }
                    startIndex = i;
                    count = 1;
                }
            }
            return list.GetRange(maxStartIndex, maxCount);
        }

        // 2. bonus) Maximum Subsequence of integers using LINQ
        public static List<int> SubLINQ(List<int> list)
        {
            return list.Select((n, i) => new { Value = n, Index = i })
                .OrderBy(s => s.Value)
                .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
                .GroupBy(s => new { s.Value, s.Diff })
                .OrderByDescending(g => g.Count())
                .First()
                .Select(f => f.Value).ToList<int>();
        }

        // 3. a) + b)
        // roots are returned as out parameters and are dynamic,
        // because i don't know if it has real or complex solution beforehand.
        // I also return the type of the actual solution using built-in class Type
        public static Type QuadraticSolve(double a, double b, double c, out dynamic root1, out dynamic root2)
        {
            if (a == 0)
            {
                throw new Exception("Not a quadratic equation");
            }
            if (b == 0)
            {
                double sqrt = Math.Sqrt(c);
                root1 = sqrt;
                root2 = -sqrt;
                return root1.GetType();
            }
            double d = Math.Pow(b, 2) - 4 * a * c;
            if (d == 0)
            {
                root1 = (-b) / (2 * a);
                root2 = root1;
                return root1.GetType();
            }
            else if (d > 0)
            {
                root1 = (-b + Math.Sqrt(d)) / (2 * a);
                root2 = -root1;
                return root1.GetType();
            }
            else
            {
                root1 = (new Complex(-b, 0) + new Complex(0, Math.Sqrt(Math.Abs(d)))) / (new Complex(2, 0) * new Complex(a, 0));
                root2 = (new Complex(-b, 0) - new Complex(0, Math.Sqrt(Math.Abs(d)))) / (new Complex(2, 0) * new Complex(a, 0));
                return root1.GetType();
            }
        }

        // Test method just to show dynamic keyword
        public static dynamic Test(int a)
        {
            if (a < 10)
            {
                return a;
            }
            else
            {
                return new Fraction(a, a);
            }
        }
    }
}
