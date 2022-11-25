using KTPO4310.Tarasov.Lib.src.LogAn;
using KTPO4310.Tarasov.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.UnitTest.src.Sample
{
    class FirstSampleCommandTest
    {
        [Test]
        public void Execute_WhenCalled_PrintsNumberOfCalls()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand command = new FirstCommand(mockView);
            command.Execute();
            mockView.Received().Render("KTPO4310.Tarasov.Lib.src.SampleCommands.FirstCommand\n iExecute = 1");
            command.Execute();
            mockView.Received().Render("KTPO4310.Tarasov.Lib.src.SampleCommands.FirstCommand\n iExecute = 2");
        }
    }
}
