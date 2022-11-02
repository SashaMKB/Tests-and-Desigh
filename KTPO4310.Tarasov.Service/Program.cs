using System;
using System.Collections.Generic;
using System.Text;
using KTPO4310.Tarasov.Lib.src.LogAn;

namespace KTPO4310.Tarasov.Service
{
    class Program 
    {
        static void Main(string[] Args) {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            Console.WriteLine("Valid:");
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.tag"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.TAG"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.tAg"));
            Console.WriteLine("INValid:");
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid."));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid.txt"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid.?"));
            Console.ReadKey();
        }
    }
}
