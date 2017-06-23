using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    abstract class SourceCodeAnalyzer
    {
        public MetricSet Metrics { get; protected set; }
        public string SourceCode { get; protected set; }

        public SourceCodeAnalyzer(string sourceCode)
        {
            SourceCode = sourceCode;
            Metrics = new MetricSet();
        }

        public abstract int CalculateLinesOfCode();
        public abstract int CalculateNumberOfClasses();
        public abstract int CalculateNumberOfMethods();

        public void CalculateAll()
        {
            CalculateLinesOfCode();
            CalculateNumberOfClasses();
            CalculateNumberOfMethods();
        }

        public string GetMetricsInCSV()
        {
            return Metrics.ToString();
        }

    }
}
