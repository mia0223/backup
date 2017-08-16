using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
   [TestClass]
   public class SeatChangeLogMapperUnitTest
   {
      private Entity.SeatChangeLog seatChangeLogEntity;

      [TestInitialize]
      public void Initialize()
      {
         seatChangeLogEntity = new Entity.SeatChangeLog
         {
            ActionDate = DateTime.Now,
            Employee = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>(),
            Id = 123,
            SourceSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>(),
            TargetSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>()
         };
      }

      [TestClass]
      public class WhenToDtoForOneSeatChangeLog : SeatChangeLogMapperUnitTest
      {
         [TestMethod]
         public void ConvertFromEntityWhenEntityIsValid()
         {
            var dto = seatChangeLogEntity.ToDto();

            DtoGenericUtils.IsEqual(seatChangeLogEntity.Employee, dto.Employee);
            DtoGenericUtils.IsEqual(seatChangeLogEntity.SourceSeat, dto.SourceSeat);
            DtoGenericUtils.IsEqual(seatChangeLogEntity.TargetSeat, dto.TargetSeat);
            DtoGenericUtils.IsEqual(seatChangeLogEntity, dto);
         }

         [TestMethod]
         public void ReturnsNullWhenEntityIsNull()
         {
            var dto = ((Entity.SeatChangeLog)null).ToDto();

            Assert.IsNull(dto);
         }
      }


      [TestClass]
      public class WhenToDtoForSeatChangeLogCollection : SeatChangeLogMapperUnitTest
      {
         [TestMethod]
         public void ConvertFromEntityWhenEntityCollectionIsValid()
         {
            List<Entity.SeatChangeLog> entityCollection = new List<Entity.SeatChangeLog>
            {
               DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.SeatChangeLog>(s=>
               {
                  s.Employee = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
                  s.Id = 1;
                  s.SourceSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
                  s.TargetSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
               }),
               DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.SeatChangeLog>(s=>
               {
                  s.Employee = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
                  s.Id = 2;
                  s.SourceSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
                  s.TargetSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
               }),
               DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.SeatChangeLog>(s=>
               {
                  s.Employee = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
                  s.Id = 3;
                  s.SourceSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
                  s.TargetSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
               }),
               DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.SeatChangeLog>(s=>
               {
                  s.Employee = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
                  s.Id = 4;
                  s.SourceSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
                  s.TargetSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
               }),
            };
            var dto = entityCollection.ToDto().ToList();

            Assert.AreEqual(entityCollection.Count, dto.Count);
            for (int i = 0; i < dto.Count; i++)
            {
               DtoGenericUtils.IsEqual(entityCollection[i].Employee, dto[i].Employee);
               DtoGenericUtils.IsEqual(entityCollection[i].SourceSeat, dto[i].SourceSeat);
               DtoGenericUtils.IsEqual(entityCollection[i].TargetSeat, dto[i].TargetSeat);
               DtoGenericUtils.IsEqual(entityCollection[i], dto[i]);
            }
         }

         [TestMethod]
         public void ReturnsAnEmptyListWhenEntityCollectionIsEmpty()
         {
            List<Entity.SeatChangeLog> entityCollection = new List<Entity.SeatChangeLog>();

            var dto = entityCollection.ToDto().ToList();

            Assert.AreEqual(0, dto.Count);
         }

         [TestMethod]
         public void ReturnsNullWhenEntityCollectionIsNull()
         {
            List<Entity.SeatChangeLog> entityCollection = null;

            var dto = entityCollection.ToDto();

            Assert.IsNull(dto);
         }
      }


   }
}
