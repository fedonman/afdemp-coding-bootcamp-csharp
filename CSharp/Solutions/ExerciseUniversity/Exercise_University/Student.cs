using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_University
{
    class Student
    {
        public string Name { get; private set; }
        public double Mark { get; set; }

        public Student(string name)
        {
            Name = name;
        }



    }
}
