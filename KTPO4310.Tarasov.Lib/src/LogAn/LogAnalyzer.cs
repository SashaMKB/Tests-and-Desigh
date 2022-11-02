using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{/// <summary> Анализатор лог.файлов </summary>

    public class LogAnalyzer
    {
        /// <summary> Проверка подлинности имени файла </summary>
        public bool IsValidLogFileName(string fileName) {
            IExtensionManager mrg = ExtensionManagerFactory.Create();
            try
            {
                return mrg.IsValid(fileName);
            }
            catch (Exception )
            {
                return false;
            }
        }

        ///<summary> Анализировать лог файл </summary>
        ///<param name="fileName"></param>
        public void Analyze(string fileName) {
            if (fileName.Length < 8) {
                try
                {
                    IWebService webService = WebServiceFactory.Create();
                    webService.LogError("Слишком короткое имя файла: " + fileName);
                }
                catch (Exception e) {
                    IEmailService emailService = EmailServiceFactory.Create();
                    emailService.SendEmail("somebody@gmail.com","Невозможно вызвать веб сервис",e.Message); //здесь можно сломать тест
                }
            }
        }
    }
}
