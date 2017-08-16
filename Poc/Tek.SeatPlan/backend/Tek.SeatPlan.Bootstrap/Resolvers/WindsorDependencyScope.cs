using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace Tek.SeatPlan.Bootstrap.Resolvers
{
   public class WindsorDependencyScope : IDependencyScope
   {
      private readonly IKernel _kernel;
      private readonly IDisposable _disposable;

      public WindsorDependencyScope(IKernel kernel)
      {
         _kernel = kernel;
         _disposable = kernel.BeginScope();
      }

      public void Dispose()
      {
         _disposable.Dispose();
      }

      public object GetService(Type serviceType)
      {
         return _kernel.HasComponent(serviceType) ? _kernel.Resolve(serviceType) : null;
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         return _kernel.ResolveAll(serviceType).Cast<object>();
      }
   }
}