using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2
{
    /// <summary>
    /// Απλό demo προγράμματος χωρίς κλάση όπου επιλέγετε κάποιον αριθμό, ρίχνετε ένα ζάρι και
    /// βλέπετε αν τον βρήκατε και μετά κάνετε ακριβώς το ίδιο για ακόμη μία φορά.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Give me a number between 1 and 6:");
            string NumberStr1 = Console.ReadLine();
            int Number1 = Int32.Parse(NumberStr1);

            Console.Write("Give me a number between 1 and 6:");
            string NumberStr2 = Console.ReadLine();
            int Number2 = Int32.Parse(NumberStr1);

            Random r = new Random();
            int LotteryNumber1 = r.Next(1, 7);
            if (Number1 == LotteryNumber1)
                Console.WriteLine("You win");
            else
                Console.WriteLine("You loose. The number was " + LotteryNumber1.ToString());

            int LotteryNumber2 = r.Next(1, 7);
            if (Number2 == LotteryNumber2)
                Console.WriteLine("You win");
            else
                Console.WriteLine("You loose. The number was " + LotteryNumber2.ToString());

            Console.ReadKey();
        }

        // Ο παρακάτω κώδικας σε σχόλια κάνει το ίδιο με for-loop.
        //public static void Main(string[] args)
        //{
        //    Random r = new Random();

        //    for (int i = 0; i < 2; i++)
        //    {
        //        Console.Write("Give me a number between 1 and 6:");
        //        string NumberStr = Console.ReadLine();
        //        int Number = Int32.Parse(NumberStr);
        //        int LotteryNumber = r.Next(1, 7);
        //        if (Number == LotteryNumber)
        //            Console.WriteLine("You win");
        //        else
        //            Console.WriteLine("You loose. The number was " + LotteryNumber.ToString());
        //    }
        //    Console.ReadKey();
        //}

    }
}