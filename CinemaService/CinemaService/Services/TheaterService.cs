using System.Collections.Generic;
using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces.ITheater;

namespace CinemaService.Services
{
   public class TheaterService : ITheaterService
   {
      private ITheaterRepository repository;
      public IMapper mapper;
      public TheaterService(ITheaterRepository repository, IMapper mapper)
      {
         this.repository = repository;
         this.mapper = mapper;
      }

      public IEnumerable<TheaterResponse> GetAll()
      {
         return mapper.Map<IEnumerable<TheaterResponse>>(repository.GetAll());
      }

      public TheaterResponse GetById(int id)
      {
         return mapper.Map<TheaterResponse>(repository.GetById(id));
      }
   }
}