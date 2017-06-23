using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            SourceCodeAnalyzerFacade facade = new SourceCodeAnalyzerFacade();
            facade.AnalyzeSourceCode("SourceCodeAnalyzer.cs", "StringMethodResults.txt", AnalyzerMethod.String);
            facade.AnalyzeSourceCode("SourceCodeAnalyzer.cs", "RegexMethodResults.txt", AnalyzerMethod.String);
        }
    }
}
