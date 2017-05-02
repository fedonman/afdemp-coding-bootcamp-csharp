using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3
{
    public class Dicet
    {
        public Random r { get; set; }

        public string Id { get; set; }
        public int Result { get; set; }
        public int Choice { get; set; }

        public bool Success { get; set; }


        public int WonTimes { get; set; }
        public int Times { get; set; }
        public int LostTimes
        {
            get
            {
                return Times - WonTimes;
            }
        }

        public decimal LostPerc
        {
            get
            {
                return LostTimes / Times;
            }
        }
        public Dicet()
        {
            r = new Random();

            WonTimes = 0;
            Times = 0;
        }
        public void Throw(int Number)
        {
            Times++;
            Choice = Number;
            Result = r.Next(1, 7);
            if (Number == Result)
            {
                Success = true;
                WonTimes++;
            }
            else
            {
                Success = false;
            }
        }

    }
}
