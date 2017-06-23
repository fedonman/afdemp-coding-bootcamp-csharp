using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public enum AnalyzerMethod { String, Regex }

    class SourceCodeAnalyzerFactory
    {
        public SourceCodeAnalyzer CreateSourceCodeAnalyzer(AnalyzerMethod method, string source)
        {
            switch(method)
            {
                case AnalyzerMethod.String:
                    return new StringAnalyzer(source);
                case AnalyzerMethod.Regex:
                    return new RegexAnalyzer(source);
                default:
                    return new StringAnalyzer(source);
            }
        }
    }
}
