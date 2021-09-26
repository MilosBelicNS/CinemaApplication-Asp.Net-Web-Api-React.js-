using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Models;
using CinemaService.Models.DTOs;


namespace CinemaService.App_Start
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<Movie, MovieResponse>();
         CreateMap<Movie, MovieById>();
         CreateMap<MovieById, Movie>();
         CreateMap<MovieRequest, Movie>();

         CreateMap<Projection, ProjectionResponse>();
         CreateMap<Projection, ProjectionById>();
         CreateMap<ProjectionById, Projection>();
         CreateMap<ProjectionRequest, Projection>();

         CreateMap<Ticket, TicketDtoAdmin>();
         CreateMap<Ticket, TicketById>();
         CreateMap<TicketRequest, Ticket>();

         CreateMap<Theater, TheaterResponse>();
         CreateMap<TheaterResponse, Theater>();

         CreateMap<ProjectionType, ProjectionTypeResponse>();
         CreateMap<ProjectionTypeResponse, ProjectionType>();



      }
   }
}