using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{/// <summary> Анализатор лог.файлов </summary>

    public class LogAnalyzer
    {

        public IExtensionManager iExtensionManager;
        public LogAnalyzer(IExtensionManager manager) {
            iExtensionManager = manager;
        }
        /// <summary> Проверка подлинности имени файла </summary>
        public bool IsValidLogFileName(string fileName) {
            IExtensionManager mrg = iExtensionManager;
            try
            {
                return mrg.IsValid(fileName);
            }
            catch {
                return false;
            }
        }
    }
}
