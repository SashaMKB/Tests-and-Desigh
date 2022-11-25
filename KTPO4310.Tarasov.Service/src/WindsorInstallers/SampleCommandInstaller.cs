using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4310.Tarasov.Lib.src.SampleCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4310.Tarasov.Service.src.WindsorInstallers
{
    class SampleCommandInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<ExceptionInterpreter>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SecondCommand>().LifeStyle.Singleton
               );
        }
    }
}
