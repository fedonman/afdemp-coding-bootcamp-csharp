using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class SourceCodeAnalyzerFacade
    {
        public void AnalyzeSourceCode(string inputFilepath, string outputFilepath, AnalyzerMethod method)
        {
            string sourceCode = FileUtilitiy.ReadFile(inputFilepath);
            SourceCodeAnalyzer analyzer = new SourceCodeAnalyzerFactory().CreateSourceCodeAnalyzer(method, sourceCode);
            analyzer.CalculateAll();
            FileUtilitiy.WriteFile(outputFilepath, analyzer.GetMetricsInCSV());
        }
    }
}
