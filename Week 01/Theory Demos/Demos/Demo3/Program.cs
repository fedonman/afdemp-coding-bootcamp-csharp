using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3
{
    /// <summary>
    /// Απλό demo προγράμματος με κλάση όπου επιλέγετε κάποιον αριθμό, ρίχνετε ένα ζάρι και
    /// βλέπετε αν τον βρήκατε και μετά κάνετε ακριβώς το ίδιο για ακόμη μία φορά.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Dice dice = new Dice();
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Give me a number between 1 and 6:");
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
