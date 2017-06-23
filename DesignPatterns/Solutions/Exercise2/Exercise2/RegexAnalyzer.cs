using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class RegexAnalyzer : SourceCodeAnalyzer
    {
        public RegexAnalyzer(string sourceCode) : base(sourceCode)
        {
        }

        public override int CalculateLinesOfCode()
        {
            return Metrics.LinesOfCode = Regex.Matches(SourceCode, "\n").Count;
        }

        public override int CalculateNumberOfClasses()
        {
            return Metrics.NumberOfClasses= Regex.Matches(SourceCode, @"\s+class\s+").Count;
        }

        public override int CalculateNumberOfMethods()
        {
            return Metrics.NumberOfMethods = Regex.Matches(SourceCode, @"\([\s\w]*\)\s*({\s*\n|\n\s*{)").Count;
        }
    }
}
