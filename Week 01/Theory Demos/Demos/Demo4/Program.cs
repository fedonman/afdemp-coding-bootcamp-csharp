using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n1=Int32.Parse(Console.ReadLine());
            int n2 = Int32.Parse(Console.ReadLine());

            Dice d = new Dice();
            d.Choice = 5;
            ChangeDice(d);
            Console.WriteLine(d.Choice);
            Console.ReadKey();
        }

        public static void ChangeDice(Dice a)
        {
            a = new Dice();
            a.Choice = 6;
        }
    }
}
