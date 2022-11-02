using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
