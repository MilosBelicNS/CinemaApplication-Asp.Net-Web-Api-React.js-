using AutoMapper;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaService.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMapper mapper;
        IMovieService movieService { get; set; }

        public MovieController(IMapper mapper,IMovieService movieService)
        {
            this.mapper = mapper;
            this.movieService = movieService;
        }


        public IHttpActionResult GetAll()
        {


            var responses = movieService.GetAll()
                                        .AsEnumerable()
                                        .Select(mapper.Map<Movie, MovieResponse>);
            return Ok(responses);
        }
    }
}
