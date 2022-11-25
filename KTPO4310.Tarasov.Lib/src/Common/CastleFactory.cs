using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Lib.src.Common
{
    public static class CastleFactory
    {
        public static IWindsorContainer container { get; private set; }

        static CastleFactory() {
            container = new WindsorContainer();
        }
    }
}
