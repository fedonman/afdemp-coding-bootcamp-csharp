using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_2
{
    public class Dice
    {
        public bool Cheat { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public Random r { get; set; }
        public string Id { get; set; }
        public int Result { get; set; }
        public int Choice { get; set; }
        public bool Success { get; set; }

        public Dice(int minValue,int maxValue)
        {
            r = new Random();
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public void Throw(int Number)
        {
            Choice = Number;
            if (Cheat==true) 
                Result = r.Next(MinValue, MaxValue+2);
            else
                Result = r.Next(MinValue, MaxValue+1);

            if (Number == Result)
                Success = true;
            else
            {
                if ((Result == (MaxValue + 1)) && Cheat)
                    Result = Choice == MaxValue ? 1 : Choice + 1;

                Success = false;
            }
        }

    }
}
