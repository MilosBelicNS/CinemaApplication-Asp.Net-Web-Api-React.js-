using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Services
{
    public class MovieService : IMovieService
    {

        public IMovieRepository repository { get; set; }

        public MovieService(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Movie> GetAll()
        {
            return repository.GetAll();
        }
    }
}