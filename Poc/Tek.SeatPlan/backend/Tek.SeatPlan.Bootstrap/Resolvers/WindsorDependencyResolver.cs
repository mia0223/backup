using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;

namespace Tek.SeatPlan.Bootstrap.Resolvers
{
   public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
   {
      private readonly IKernel _kernel;

      public WindsorDependencyResolver(IKernel kernel)
      {
         _kernel = kernel;
      }

      public void Dispose()
      {
      }

      public object GetService(Type serviceType)
      {
         return _kernel.HasComponent(serviceType) ? _kernel.Resolve(serviceType) : null;
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         return _kernel.ResolveAll(serviceType).Cast<object>();
      }

      public IDependencyScope BeginScope()
      {
         return new WindsorDependencyScope(_kernel);
      }

   }
}