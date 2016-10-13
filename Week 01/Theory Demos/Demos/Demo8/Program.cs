using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dice dice = new Dice();
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Give me a number between 1 and 6:");
                string NumberStr = Console.ReadLine();
                dice.Throw(NumberStr);
                if (dice.Success)
                    Console.WriteLine("You win");
                else
                {
                    Console.WriteLine($"You loose. The number was {dice.Choice.ToString()}");
                }
            }
            Console.ReadKey();


            DiceWithSecondChoice Dice = new DiceWithSecondChoice(4);
            Console.Write("Give me a number between 1 and 6:");
            string NumberStr1 = Console.ReadLine();
            Dice.ThrowSecondChoice(NumberStr1);
            if (Dice.Success)
                Console.WriteLine("You win");
            else
            {
                Console.WriteLine($"You loose. The number was {Dice.Choice.ToString()}");
            }

            DiceWithSecondChoiceOverride DiceNew = new DiceWithSecondChoiceOverride(4);
            Console.Write("Give me a number between 1 and 6:");
            NumberStr1 = Console.ReadLine();
            DiceNew.Throw(NumberStr1);
            if (DiceNew.Success)
                Console.WriteLine("You win");
            else
            {
                Console.WriteLine($"You loose. The number was {DiceNew.Choice.ToString()}");
            }


        }
    }
}
