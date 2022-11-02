using NUnit.Framework;
using KTPO4310.Tarasov.Lib.src.LogAn;
using System;

namespace KTPO4310.Tarasov.UnitTest.src.LogAn
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [TearDown]
        public void AfterEachTest() {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.setWebService(null);
            EmailServiceFactory.setEmailService(null);
        }
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            //Подготовка Теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

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
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();

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
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //воздействие на тестируемый объект 
            bool result = log.IsValidLogFileName("short.tag");
            Assert.False(result);
            //Проверка ожидаемого результат 
            }

        [Test]
        public void Analyze_TooShortFileName_CallWebService() {
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.setWebService(mockWebService);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.tag";
            log.Analyze(tooShortFileName);
            StringAssert.Contains("Слишком короткое имя файла: " + tooShortFileName, mockWebService.lastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail() {
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.setWebService(stubWebService);
            stubWebService.WilThrow = new Exception("Подделка");

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.setEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.tag";
            log.Analyze(tooShortFileName);

            StringAssert.Contains("somebody@gmail.com", mockEmail.To);
            StringAssert.Contains("Подделка",mockEmail.Body);//здесь можно сломать тест
            StringAssert.Contains("Невозможно вызвать веб сервис", mockEmail.Subject);
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

    internal class FakeWebService: IWebService
    {
        public string lastError;
        public Exception WilThrow;
        public void LogError(string message) {
            if (WilThrow != null) {
                throw WilThrow;
            }
            lastError = message;
        }
    }

    internal class FakeEmailService : IEmailService {
        public string To;
        public string Subject;
        public string Body;
        public void SendEmail(string To, string Subject, string Body) {
            this.To = To;
            this.Subject = Subject;
            this.Body = Body;
        }
    }
}
