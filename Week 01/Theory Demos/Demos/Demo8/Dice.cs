using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo8
{
    
    //Dice with overload
    public class Dice
    {
        public Random r { get; set; }
        public string Id { get; set; }
        public int Result { get; set; }
        public int Choice { get; set; }
        public bool Success { get; set; }

        public Dice()
        {
            r = new Random();
        }
        public void Throw(int Number)
        {
            Choice = Number;
            Result = r.Next(1, 7);
            if (Number == Result)
                Success = true;
            else
                Success = false;
        }

        public void Throw (float number)
        {
            Throw((int)Math.Floor(number));
        }

        public void Throw(string number)
        {
            Throw(Int32.Parse(number));
        }
    }

    //Dice with inheritance
    public class DiceWithSecondChoice : Dice
    {
        public int SecondChoice { get; set; }

        public DiceWithSecondChoice(int SecondChoice)
        {
            this.SecondChoice = SecondChoice;
        }
        public void ThrowSecondChoice(int Number)
        {
            Throw(Number);
            if (!this.Success)
                Throw(SecondChoice);
        }

        public void ThrowSecondChoice(string Number)
        {
            Throw(Number);
            if (!this.Success)
                Throw(SecondChoice);
        }

    }

    //Dice with inheritance and overriding
    public class DiceWithSecondChoiceOverride : Dice
    {
        public int SecondChoice { get; set; }

        public DiceWithSecondChoiceOverride(int SecondChoice)
        {
            this.SecondChoice = SecondChoice;
        }
        public void Throw(int Number)
        {
            Throw(Number);
            if (!this.Success)
                Throw(SecondChoice);
        }

        public void Throw(string Number)
        {
            Throw(Number);
            if (!this.Success)
                Throw(SecondChoice);
        }

    }
}
