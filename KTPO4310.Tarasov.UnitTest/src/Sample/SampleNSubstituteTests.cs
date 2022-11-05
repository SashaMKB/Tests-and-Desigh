using NUnit.Framework;
using KTPO4310.Tarasov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;

namespace KTPO4310.Tarasov.UnitTest.src.Sample
{
    class SampleNSubstituteTests
    {
        [Test]
        public void Returns_ParticularArg_Works() {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного входного параметра
            fakeExtensionManager.IsValid("valid.tag").Returns(true);

            //Воздейсвтие на тестируемый объект 
            bool result = fakeExtensionManager.IsValid("valid.tag");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_ArgAny_Works() {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного входного параметра
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            //Воздейсвтие на тестируемый объект 
            bool result = fakeExtensionManager.IsValid("somefile.txt");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_ArgAny_Throws() {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.When(x =>x.IsValid(Arg.Any<String>()))
                .Do(context => { throw new Exception("fake exception"); });
            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));
        }

        [Test]
        public void Received_ParticularArg_Saves() {
            IWebService mockWebService = Substitute.For<IWebService>();
            mockWebService.LogError("Fake message");// f->F можно выбить ошибку в тесте
            mockWebService.Received().LogError("Fake message");
        }
    }
}
