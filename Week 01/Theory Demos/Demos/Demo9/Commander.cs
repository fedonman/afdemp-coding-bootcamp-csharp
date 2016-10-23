using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class SayHello : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Hello");
        }

        public void Undo()
        {
            Console.WriteLine("No hello");
        }
    }


    // Command pattern implementation
    public class Commander
    {
        public List<ICommand> Commands { get; set; }

        public Commander()
        {
            Commands = new List<ICommand>();
        }

        public void AddCommand(ICommand c)
        {
            Commands.Add(c);
        }

        public void Execute()
        {
            foreach (ICommand c in Commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in Commands)
                c.Undo();
        }
    }
}
