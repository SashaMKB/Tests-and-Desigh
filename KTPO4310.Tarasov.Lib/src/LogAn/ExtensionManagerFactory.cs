using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика диспечеров расширений файлов
    /// </summary>
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager customManger = null;
        /// <summary>
        /// Создание объекта
        /// </summary>
        public static IExtensionManager Create() {
            if (customManger != null) {
                return customManger;
            }
            return new FileExtensionManager();
        }
        /// <summary>
        /// Метод позволит тестам контролировать
        /// , что возваращет фабрика
        /// </summary>
        /// <param name="mgr"?></param>
        public static void SetManager(IExtensionManager mgr) {
            customManger = mgr;

        }
    }
}
