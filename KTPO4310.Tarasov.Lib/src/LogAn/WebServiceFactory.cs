using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.LogAn
{
    public class WebServiceFactory
    {
        private static IWebService webService;
        public static IWebService Create() {
            if (webService != null) {
                return (webService);
            }
            return (new WebService());
        }
        public static void setWebService(IWebService iwb) {
            webService = iwb;
        }
    }
}
