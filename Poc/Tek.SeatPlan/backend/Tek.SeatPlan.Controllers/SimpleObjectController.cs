using System;
using System.Collections.Generic;
using System.Web.Http;
using Tek.SeatPlan.Business;
using Tek.SeatPlan.Dtos;

namespace Tek.SeatPlan.Controllers
{
   public class SimpleObjectController : ApiController
   {
      private readonly ISimpleObjectLogic _logic;

      public SimpleObjectController(ISimpleObjectLogic logic)
      {
         _logic = logic ?? throw new ArgumentNullException(nameof(logic));
      }

      // GET: api/SimpleObject
      public IEnumerable<SimpleObjectDto> Get()
      {
         return _logic.GetAll();
      }

      // GET: api/SimpleObject/5
      public SimpleObjectDto Get(int id)
      {
         return _logic.Get(id);
      }

      // POST: api/SimpleObject
      public SimpleObjectDto Post([FromBody]SimpleObjectDto value)
      {
         return _logic.Create(value);
      }

      // PUT: api/SimpleObject/5
      public SimpleObjectDto Put(int id, [FromBody]SimpleObjectDto value)
      {
         return _logic.Update(id, value);
      }

      // DELETE: api/SimpleObject/5
      public SimpleObjectDto Delete(int id)
      {
         return _logic.Delete(id);

      }
   }
}
