using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DoubleDice dd = new DoubleDice(new Dice(1, 6), new Dice(1, 6));
            while (Console.ReadKey().KeyChar != 'q')
            {
                dd.Throw();
                Console.WriteLine(dd.GetResults());
            }
            
        }
    }
}
