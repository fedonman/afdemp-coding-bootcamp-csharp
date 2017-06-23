using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class StringAnalyzer : SourceCodeAnalyzer
    {
        public StringAnalyzer(string sourceCode) : base(sourceCode)
        {
        }

        public override int CalculateLinesOfCode()
        {
            return Metrics.LinesOfCode = SourceCode.Split('\n').Length;
        }

        public override int CalculateNumberOfClasses()
        {
            int counter = 0;
            SourceCode.Split('\n').ToList().ForEach(delegate (string line) {
                if (line.Contains(" class "))
                {
                    counter++;
                }
            });
            return Metrics.NumberOfClasses = counter;
        }

        public override int CalculateNumberOfMethods()
        {
            int counter = 0;
            bool flag = false;
            SourceCode.Replace(" ","").Replace("\t", "").Split('\n').ToList().ForEach(delegate (string line)
            {
                if (flag && line.Contains("{")) {
                    counter++;
                    flag = false;
                }
                if (line.Contains("(") && line.Contains(")") && !line.Contains("if") && !line.Contains("for") && !line.Contains("switch") && !line.Contains("while") && !line.Contains(".")) {
                    if (line.Contains("{"))
                    {
                        counter++;
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            });
            return Metrics.NumberOfMethods = counter;
        }
    }
}
