using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Tek.SeatPlan.Dtos;
using Tek.SeatPlan.Models;
using Tek.SeatPlan.ResourceGateway;

namespace Tek.SeatPlan.Business
{
   public class SimpleObjectLogic : ISimpleObjectLogic
   {
      private readonly IRepository<SimpleObject> _repository;
      private readonly IMapper _mapper;

      public SimpleObjectLogic(IRepository<SimpleObject> repository, IMapper mapper)
      {
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
         _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      }

      public SimpleObjectDto Create(SimpleObjectDto simpleObject)
      {
         var model = _mapper.Map<SimpleObject>(simpleObject);
         var newEntity = _repository.Insert(model);
         return _mapper.Map<SimpleObjectDto>(newEntity);
      }

      public IEnumerable<SimpleObjectDto> GetAll()
      {
         return _repository.GetAll().Select(m => _mapper.Map<SimpleObjectDto>(m)).ToList();
      }

      public SimpleObjectDto Get(int id)
      {
         var foundEntity= _repository.SearchFor(s => s.Id == id).SingleOrDefault();
         return _mapper.Map<SimpleObjectDto>(foundEntity);
      }

      public SimpleObjectDto Update(int id, SimpleObjectDto simpleObject)
      {
         var foundEntity = _repository.SearchFor(s => s.Id == id).SingleOrDefault();
         if (foundEntity == null)
            return null;

         simpleObject.Id = id;

         var e = _mapper.Map<SimpleObject>(simpleObject);
         var updatedEntity= _repository.Update(e);
         return _mapper.Map<SimpleObjectDto>(updatedEntity);
      }

      public SimpleObjectDto Delete(int id)
      {
         var foundEntity = _repository.SearchFor(s => s.Id == id).SingleOrDefault();
         if (foundEntity == null)
            return null;

         var deletedEntity = _repository.Delete(foundEntity);
         return _mapper.Map<SimpleObjectDto>(deletedEntity);
      }
   }
}
