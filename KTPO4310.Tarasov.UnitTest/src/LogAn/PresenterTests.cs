using KTPO4310.Tarasov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.UnitTest.src.LogAn
{
    class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender() {
            FakeLogAnalyzer fakeLogAnalyzer = new FakeLogAnalyzer();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(fakeLogAnalyzer,view);

            fakeLogAnalyzer.CallRaiseAnalyzedevent();
            view.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute() {
            ILogAnalyzer fakeLogAnalyzer = Substitute.For<ILogAnalyzer>();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(fakeLogAnalyzer, view);

            fakeLogAnalyzer.Analyzed+=Raise.Event<LogAnalyzerAction>();
            view.Received().Render("Обработка завершена");
        }
    }

    class FakeLogAnalyzer : LogAnalyzer {
        public void CallRaiseAnalyzedevent() {
            base.RaiseAnalyzedEvent();
        }
    }
}
