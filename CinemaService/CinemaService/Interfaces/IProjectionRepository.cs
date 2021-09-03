using CinemaService.Models;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionRepository
    {
        
        IEnumerable<Projection> GetAll();
        Projection GetById(int id);
        void Create(Projection Projection);
        void Delete(int id);
        //IEnumerable<Projection> GetByMovie(int movieId);//sve projekcije za dati film
        //IQueryable<Projection> GetByFilter(ProjectionFilter projectionFilter);//projekcije po filteru




    }
}
