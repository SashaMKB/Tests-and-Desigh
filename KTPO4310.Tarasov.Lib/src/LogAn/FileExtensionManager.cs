using System;
using System.Configuration;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            string extension = ConfigurationManager.AppSettings.Get("extension");
            if (string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException("File name must be given");

            }
            if (fileName.ToUpper().EndsWith(extension)) {
                return true;
            }
            return false;
        }
    }
}