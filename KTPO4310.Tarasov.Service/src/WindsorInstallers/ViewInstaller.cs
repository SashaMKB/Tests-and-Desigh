using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4310.Tarasov.Lib.src.LogAn;
using KTPO4310.Tarasov.Service.src.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Service.src.WindsorInstallers
{
    class ViewInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer cotainer, IConfigurationStore store) {

            cotainer.Register(
                Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Transient
                );
        }
    }
}
