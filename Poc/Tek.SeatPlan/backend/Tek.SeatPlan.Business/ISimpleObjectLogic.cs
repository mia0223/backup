using System.Collections.Generic;
using Tek.SeatPlan.Dtos;

namespace Tek.SeatPlan.Business
{
   public interface ISimpleObjectLogic
   {
      SimpleObjectDto Create(SimpleObjectDto simpleObject);
      SimpleObjectDto Delete(int id);
      SimpleObjectDto Get(int id);
      IEnumerable<SimpleObjectDto> GetAll();
      SimpleObjectDto Update(int id, SimpleObjectDto simpleObject);
   }
}