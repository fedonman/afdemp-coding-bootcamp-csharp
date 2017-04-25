using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(FileUtility.Instance.ReadFile("../../Test.txt"));
            Console.WriteLine("-----");
            FileUtility.Instance.WriteToFile("../../Test.txt", "Hello World", true);
            Console.Write(FileUtility.Instance.ReadFile("../../Test.txt"));

            Console.ReadKey();
        }
    }
}
