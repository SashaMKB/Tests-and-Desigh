using NUnit.Framework;
using KTPO4310.Tarasov.Lib.src.LogAn;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.UnitTest.src.LogAn
{
    class LogAnalyzerNSubstituteTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue() {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("valid.tag").Returns(true);

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("valid.tag");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("a.tag").Returns(false);

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("a.tag");
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse() {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager
                .When(x => x.IsValid("file.tag"))
                .Do(context => { throw new Exception(); });

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("file.tag");
            Assert.False(result);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService() {
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.setWebService(mockWebService);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.tag";
            log.Analyze(tooShortFileName);
            mockWebService.Received().LogError("Слишком короткое имя файла: " + tooShortFileName); //поставь пробел выпадет ошибка
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail() {

            Exception ThrownException = new Exception();

            IWebService stubWebService = Substitute.For<IWebService>();
            stubWebService
                .When(x => x.LogError(Arg.Any<String>()))
                .Do(context => { throw ThrownException; });
            WebServiceFactory.setWebService(stubWebService);

            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.setEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.tag";
            log.Analyze(tooShortFileName);

            mockEmail.Received().SendEmail("somebody@gmail.com", "Невозможно вызвать веб сервис", ThrownException.Message);
        }
    }
}
