using AutoMapper;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieResponse>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();

            CreateMap<MovieRequest, Movie>();

          
        }
    }
}