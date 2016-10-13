using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dice dice = new Dice(1,20);
            dice.Cheat = true;
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Give me a number between {dice.MinValue} and {dice.MaxValue}:");
                string NumberStr = Console.ReadLine();
                int Number = Int32.Parse(NumberStr);

                dice.Throw(Number);
                if (dice.Success)
                    Console.WriteLine("You win");
                else
                {
                    Console.WriteLine($"You loose. The number was {dice.Choice.ToString()}");
                }
            }
            Console.ReadKey();
        }
    }
}
