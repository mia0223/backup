using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using TEK.SeatPlan.Common;
using TEK.SeatPlan.Common.ErrorHandling;

namespace TEK.SeatPlan.Ioc.Installers
{
    public class CommonServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Common.Requires.ArgumentNotNull(container, "container");

            container.Register
            (
                Types.FromAssembly(typeof(DefaultErrorHandler).Assembly)
                    .BasedOn(typeof(IErrorHandling))
                    .LifestylePerWebRequest()
            );
        }
    }
}
