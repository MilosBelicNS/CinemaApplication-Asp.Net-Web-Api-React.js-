using System.Collections.Generic;
using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces.IProjectionType;

namespace CinemaService.Services
{
   public class ProjectionTypeService : IProjectionTypeService
   {
      private IProjectionTypeRepository repository;

      public IMapper mapper;
      public ProjectionTypeService(IProjectionTypeRepository repository, IMapper mapper)
      {
         this.repository = repository;
         this.mapper = mapper;
      }

      public IEnumerable<ProjectionTypeResponse> GetAll()
      {
         return mapper.Map<IEnumerable<ProjectionTypeResponse>>(repository.GetAll());
      }

      public ProjectionTypeResponse GetById(int id)
      {
         return mapper.Map<ProjectionTypeResponse>(repository.GetById(id));
      }
   }
}