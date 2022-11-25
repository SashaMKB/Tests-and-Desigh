using KTPO4310.Tarasov.Lib.src.LogAn;
using KTPO4310.Tarasov.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.UnitTest.src.Sample
{
    class SecondCommandDecoratorTest
    {
        [Test]
        public void Execute_WhenCalled_ExecutesDecorateObjectMethod() {
            IView view = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(mockDecoratedCommand, view);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();
        }

        [Test]
        public void Execute_WhenCalled_PrintsMessage() {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            IView view = Substitute.For<IView>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(stubCommand,view);
            commandDecorator.Execute();
            view.Received().Render("Начало: KTPO4310.Tarasov.Lib.src.SampleCommands.SampleCommandDecorator");
            view.Received().Render("Конец: KTPO4310.Tarasov.Lib.src.SampleCommands.SampleCommandDecorator");
        }

    }
}
