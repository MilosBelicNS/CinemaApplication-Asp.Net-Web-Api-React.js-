using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaService.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetByFilter(MovieFilter movieFilter);
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
