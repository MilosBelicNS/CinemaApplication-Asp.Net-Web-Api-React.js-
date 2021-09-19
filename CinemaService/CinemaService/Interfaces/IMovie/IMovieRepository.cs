using CinemaService.Models;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
