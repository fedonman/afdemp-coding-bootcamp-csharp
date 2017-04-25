using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = FileUtility.Instance.ReadFile("../../StoresController.txt");
            long c1 = CountLines("../../StoresController.txt");
            long c2 = CountLinesRegex("../../StoresController.txt");
            Console.WriteLine(c1 + " | " + c2);
            Console.ReadKey();
        }

        static long CountLines(string s)
        {
            s.Split('\n');
            return s.Count();
        }

        static long CountLinesRegex(string s)
        {
            Regex pattern = new Regex("\n", RegexOptions.Multiline);
            MatchCollection mc = pattern.Matches(s);
            return mc.Count + 1;
        }
    }
}
