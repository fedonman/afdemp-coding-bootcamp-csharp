using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class MetricSet
    {
        public int LinesOfCode { get; set; }
        public int NumberOfClasses { get; set; }
        public int NumberOfMethods { get; set; }

        public override string ToString()
        {
            return LinesOfCode + "," + NumberOfClasses + "," + NumberOfMethods;
        }
    }
}
