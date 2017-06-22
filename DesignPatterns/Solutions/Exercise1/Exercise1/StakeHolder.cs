using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class StakeHolder : IObserver<Course>
    {
        public string Name { get; set; }

        public StakeHolder(string name)
        {
            Name = name;
        }

        public void OnNext(Course value)
        {
            Console.WriteLine(Name + " notified that course " + value.Name + " changed time");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

    }
}
