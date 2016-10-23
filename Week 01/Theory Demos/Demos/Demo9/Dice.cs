using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo9
{

    public abstract class DiceAbstract
    {
        public Random r { get; set; }
        public string Id { get; set; }
        public int Result { get; set; }
        public int Choice { get; set; }
        public bool Success { get; set; }

        public abstract void Throw(int Number);

        public override string ToString()
        {
            return this.Id;
        }
    }

    public class DiceFromAbstract : DiceAbstract
    {
        public override void Throw(int Number)
        {
            Choice = Number;
            Result = r.Next(1, 7);
            if (Number == Result)
                Success = true;
            else
                Success = false;
        }
    }
    public class Dice : IDice,ICommand,IDisposable
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

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public bool GetResult()
        {
            return this.Success;
        }

        public void Dispose()
        {
            // Clean up code
        }

        public void Execute()
        {
            Throw(5);
        }

        public void Undo()
        {
            Choice = 0;
        }
    }
}
