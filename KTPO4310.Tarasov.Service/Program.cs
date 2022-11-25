using System;
using System.Collections.Generic;
using System.Text;
using KTPO4310.Tarasov.Lib.src.Common;
using KTPO4310.Tarasov.Lib.src.LogAn;
using KTPO4310.Tarasov.Lib.src.SampleCommands;
using KTPO4310.Tarasov.Service.src.WindsorInstallers;

namespace KTPO4310.Tarasov.Service
{
    class Program 
    {
        static void Main(string[] Args) {
            CastleFactory.container.Install(
                new SampleCommandInstaller(),
                new ViewInstaller()
                );

            for (int i = 0; i < 3; i++)
            {
                ISampleCommand sampleCommand = CastleFactory.container.Resolve<ISampleCommand>();
                sampleCommand.Execute();
            }
        }
    }
}
