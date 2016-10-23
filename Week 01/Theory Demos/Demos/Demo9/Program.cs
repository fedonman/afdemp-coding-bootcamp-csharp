using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interfaces and Abstract classes
namespace Demo9
{

    //Abstract classes and interfaces
    class Program
    {
        static void Main(string[] args)
        {
            Commander c= new Commander();
            c.AddCommand(new Dice());
            c.AddCommand(new SayHello());
            c.Execute();
            c.Undo();

            IDice Dice1 = new Dice();
            DiceAbstract Dice2 = new DiceFromAbstract();

            using (Dice d=new Dice())
            {

            }
        }
        
    }
}
