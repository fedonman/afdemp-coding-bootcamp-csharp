using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_University
{
    class Course
    {
        public string Name { get; private set; }
        public int Ects { get; private set; }

        public Course(string name, int ects)
        {
            Name = name;
            Ects = ects;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
