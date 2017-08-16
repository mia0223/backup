using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using backend.Models;

namespace backend.Controllers
{
   [MyAuthorize]
   public class SimpleObjectController : ApiController
   {

//       public static string Role
//       {
//           get { return ConfigurationManager.AppSettings["admingroup"]; }
//       }

       
            // GET: api/SimpleObject
        private static List<SimpleObjectDTO> SimpleObjectDtos = new List<SimpleObjectDTO>(
          new SimpleObjectDTO[]{ new SimpleObjectDTO() { Name = "Mia", Age = 23, Seat = 1 },
                                 new SimpleObjectDTO(){Name = "Nathan", Age = 24, Seat = 2},
                                 new SimpleObjectDTO(){Name = "Auggi", Age = 4, Seat = 3}});


        public IEnumerable<SimpleObjectDTO> Get()
      {
         return SimpleObjectDtos;
      }

      // GET: api/SimpleObject/5
      
      public SimpleObjectDTO Get(int id)
      {
         return SimpleObjectDtos[id];
      }

      // POST: api/SimpleObject
      public void Post([FromBody]SimpleObjectDTO value)
      {
         SimpleObjectDtos.Add(value);
      }

      // PUT: api/SimpleObject/5
      public void Put(int id, [FromBody]SimpleObjectDTO value)
      {
         SimpleObjectDtos[id] = value;
      }

      // DELETE: api/SimpleObject/5
      public void Delete(int id)
      {
         SimpleObjectDtos.RemoveAt(id);
      }
   }

    public class MyAuthorize : AuthorizeAttribute
    {
        public MyAuthorize()
        {
            this.Roles = ConfigurationManager.AppSettings["admingroup"];
            //this.Users = "CORPORATE\\ccaron";
        }
    }
}
