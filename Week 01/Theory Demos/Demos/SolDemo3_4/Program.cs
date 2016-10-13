using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FortuneTeller<string> FT = new FortuneTeller<string>();
            FT.SetItems("Yes you will", "No", "Maybe", "I am sure if you try");

            Console.WriteLine("Ask me whatever you want:");
            Console.ReadLine();
            Console.WriteLine(FT.GetAnswer());

            FortuneTeller<int> FT2 = new FortuneTeller<int>();
            FT2.SetItems(0,1,2,3);

            Console.WriteLine("Ask me a question that starts with how many");
            Console.ReadLine();
            Console.WriteLine(FT2.GetAnswer());

            Console.ReadKey();

        }
    }
}
