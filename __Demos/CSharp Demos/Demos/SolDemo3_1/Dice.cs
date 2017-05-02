using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_1
{
    public class Dice
    {
        private static Random _r { get; set; }
        public string Id { get; set; }
        private int _result { get; set; }
        private int _choice { get; set; }
        public bool _success { get; set; }

        public Dice()
        {
            if (Dice._r==null)
                Dice._r = new Random();
        }
        public void Throw(int Number)
        {
            _choice = Number;
            _result = _r.Next(1, 7);
            if (Number == _result)
                _success = true;
            else
                _success = false;
        }
        public string GetResultMessage()
        {
            if (_success)
                return "You win";
            else
                return $"You loose. The number was {_choice.ToString()}";
        }

    }
}
