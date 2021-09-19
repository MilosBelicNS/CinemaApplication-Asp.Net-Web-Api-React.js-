using CinemaService.DTOs;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
   public interface IMovieService
    {
        IEnumerable<MovieResponse> GetAll();
        IEnumerable<MovieResponse> Filter(MovieFilter movieFilter);
        MovieById GetById(int id);
        void Create(MovieRequest movieRequest);
        void Update(int id, MovieRequest movieRequest);
        void Delete(int id);
    }
}
