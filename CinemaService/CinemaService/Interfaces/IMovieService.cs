using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaService.Interfaces
{
   public interface IMovieService
    {
        IEnumerable<MovieResponse> GetAll(string sortType);
        MovieResponse GetById(int id);
        void Create(MovieRequest movieRequest);
        void Update(int id, MovieRequest movieRequest);
        void Delete(int id);
    }
}
