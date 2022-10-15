using NUnit.Framework;
using KTPO4310.Tarasov.Lib.src.LogAn;
using System;

namespace KTPO4310.Tarasov.UnitTest.src.LogAn
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            //Подготовка Теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            LogAnalyzer log = new LogAnalyzer(fakeManager);

            //воздействие на тестируемый объект 
            bool result = log.IsValidLogFileName("short.tag");

            //Проверка ожидаемого результат 
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtension_ReturnsFalse()
        {
            //Подготовка Теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            LogAnalyzer log = new LogAnalyzer(fakeManager);

            //воздействие на тестируемый объект 
            bool result = log.IsValidLogFileName("short.tag");

            //Проверка ожидаемого результат 
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse() {
            //Подготовка Теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception();

            LogAnalyzer log = new LogAnalyzer(fakeManager);

            //воздействие на тестируемый объект 
            bool result = log.IsValidLogFileName("short.tag");
            Assert.False(result);
            //Проверка ожидаемого результат 
            }


    }
    /// <summary>Поддельный Менеджер расширений</summary>
    internal class FakeExtensionManager : IExtensionManager
    {
        /// <summary>
        /// это поле позволяет настроить поддельный результат для метода IsValid
        /// </summary>
        public bool WillBeValid = false;
        /// <summary>
        /// Это поле позволяет настроить поддельное исключение вызываемое в тоде Is Vаlid
        /// </summary>
        public Exception WillThrow = null;
        public bool IsValid(string fileName)
        {
            if (WillThrow != null) {
                throw WillThrow;
            }
            return WillBeValid;
        }
    }
}
