using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    /// <summary>
    /// Απλό demo προγράμματος χωρίς κλάση όπου επιλέγετε κάποιον αριθμό, ρίχνετε ένα ζάρι και
    /// βλέπετε αν τον βρήκατε.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Give me a number between 1 and 6:");
            string NumberStr = Console.ReadLine();
            int Number = Int32.Parse(NumberStr);

            Random r = new Random();
            int LotteryNumber = r.Next(1, 7);
            if (Number == LotteryNumber)
                Console.WriteLine("You win");
            else
            {
                Console.WriteLine("You loose. The number was " + LotteryNumber.ToString());

                // Βγάλτε τα σχόλια από την παρακάτω γραμμή για String interpolation option
                //Console.WriteLine($"You loose. The number was {LotteryNumber.ToString()}")
            }

            // Ο ίδιος έλεγχος με το παραπάνω αλλά με δομή ?:
            String ResultMessage = Number == LotteryNumber ? "You win" : "You loose. The number was " + LotteryNumber.ToString();
            Console.WriteLine(ResultMessage);

            Console.ReadKey();
        }
    }
}
