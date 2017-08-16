using AutoMapper;
using AutoMapper.Mappers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Linq;

namespace Tek.SeatPlan.Bootstrap.Installers
{
   public class AutoMapperInstaller : IWindsorInstaller
   {
      public void Install(IWindsorContainer container, IConfigurationStore store)
      {
         container.Register(Component.For<IMapper>().Instance(ConfigureAutoMapper()));
      }

      private IMapper ConfigureAutoMapper()
      {
         var config = new MapperConfiguration(cfg =>
         {
            cfg.AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "Dto");
            cfg.AddConditionalObjectMapper().Where((s, d) => s.Name + "Dto" == d.Name);
         });

         return config.CreateMapper();
      }
   }
}