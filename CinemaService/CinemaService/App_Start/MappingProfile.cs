using AutoMapper;
using CinemaService.Models;
using CinemaService.Models.DTOs;


namespace CinemaService.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieResponse>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieRequest, Movie>();

            CreateMap<Projection, ProjectionResponse>();

          
        }
    }
}