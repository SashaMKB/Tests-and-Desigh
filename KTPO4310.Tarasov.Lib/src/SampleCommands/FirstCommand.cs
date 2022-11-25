using KTPO4310.Tarasov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.SampleCommands
{
    public class FirstCommand: ISampleCommand
    {

        private readonly IView view;
        private int IExecute = 0;
        public FirstCommand(IView view) => this.view = view;
        public void Execute() { 
            view.Render(this.GetType().ToString() + "\n iExecute = " + (++IExecute)); 
        }
    }
}
