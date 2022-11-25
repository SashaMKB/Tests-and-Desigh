using KTPO4310.Tarasov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.SampleCommands
{
    public class ExceptionInterpreter:ISampleCommand
    {
        private readonly ISampleCommand sampleCommandDecorator;
        private readonly IView view;
        public ExceptionInterpreter(ISampleCommand sampleCommandDecorator, IView view) {
            this.sampleCommandDecorator = sampleCommandDecorator;
            this.view = view;
        }
        public void Execute() {
            try {
                sampleCommandDecorator.Execute();

            } catch {
                view.Render("Перехвачено исключение.");
            }
        }
    }
}
