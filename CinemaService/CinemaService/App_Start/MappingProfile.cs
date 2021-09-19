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
            CreateMap<MovieRequest, Movie>();

            CreateMap<Projection, ProjectionResponse>();
            CreateMap<Projection, ProjectionById>();
            CreateMap<ProjectionRequest, Projection>();

            CreateMap<Ticket, TicketDtoAdmin>();
            CreateMap<Ticket, TicketById>();
            CreateMap<TicketRequest, Ticket>();




        }
    }
}