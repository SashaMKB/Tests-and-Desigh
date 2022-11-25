using KTPO4310.Tarasov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Service.src.Views
{
    class ConsoleView:IView
    {
        public void Render(string text) {
            Console.WriteLine(text);
        } 
    }
}
