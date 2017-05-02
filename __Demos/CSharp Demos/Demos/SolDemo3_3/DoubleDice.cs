using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_3
{
    public class DoubleDice
    {
        public Dice Dice1 { get; set; }
        public Dice Dice2 { get; set; }

        public DoubleDice(Dice dice1,Dice dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public void Throw()
        {
            Dice1.Throw(2);
            Dice2.Throw(3);

        }
        public String GetResults()
        {
            return Dice1.Result.ToString() + " " + Dice2.Result.ToString();
        }
    }
}
