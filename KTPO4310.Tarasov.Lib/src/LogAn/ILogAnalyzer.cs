using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        bool IsValidLogFileName(string fileName);

        void Analyze(string filename);
        void RaiseAnalyzedEvent();
        event LogAnalyzerAction Analyzed;
    }
}
