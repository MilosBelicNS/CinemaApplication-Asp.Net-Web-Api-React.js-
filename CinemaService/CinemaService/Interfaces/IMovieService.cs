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
        IEnumerable<MovieDTO> GetAll(string sortType);//sortiranje po razlicitim parametrima
        IEnumerable<MovieDTO> GetByFilter(string filter);//pretraga po razlicitim parametrima
        MovieResponse GetById(int id);
        void Create(MovieRequest movieRequest);
        void Update(int id, MovieRequest movieRequest);
        void Delete(int id);
    }
}
