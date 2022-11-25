using System;
using System.Collections.Generic;
using System.Text;
using KTPO4310.Tarasov.Lib.src.LogAn;
using KTPO4310.Tarasov.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4310.Tarasov.UnitTest.src.Sample
{
    class ExceptionCommandDecorator
    {
        [Test]
        public void Execute_WhenCalled_ExecutesDecoratedObjectMethod() {
            IView view = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new ExceptionInterpreter(mockDecoratedCommand, view);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();
        }

        [Test]
        public void Execute_CommandThrowsException_PrintsMessage() {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            stubCommand
                .When(x => x.Execute())
                .Do(context => { throw new Exception(); });

            IView mockView = Substitute.For<IView>();

            ISampleCommand commandDecorator = new ExceptionInterpreter(stubCommand,mockView);
            commandDecorator.Execute();
            mockView.Received().Render("Перехвачено исключение.");
        }
    }
}
