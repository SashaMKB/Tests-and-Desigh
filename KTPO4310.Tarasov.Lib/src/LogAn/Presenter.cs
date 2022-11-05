using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    public class Presenter
    {

        private ILogAnalyzer LogAnalyzer;
        private IView View;

        public Presenter(ILogAnalyzer LogAnalyzer, IView view) {
            this.LogAnalyzer = LogAnalyzer;
            View = view;
            LogAnalyzer.Analyzed += OnLogAnalyzer;
        }

        private void OnLogAnalyzer() {
            View.Render("Обработка завершена");//тут тоже можно сломать тест
        }
    }
}
