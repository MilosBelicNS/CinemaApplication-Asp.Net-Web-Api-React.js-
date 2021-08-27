using CinemaService.Models;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaService.Interfaces
{
    public interface IProjectionRepository
    {

        IEnumerable<Projection> GetByDate(DateTime date);//sve projekcije za tekuci datum
        IEnumerable<Projection> GetByMovie(int movieId);//sve projekcije za dati film
        IEnumerable<Projection> GetByFilter(ProjectionFilter projectionFilter);//projekcije po filteru
        Projection GetById(int id);//projekcija po id

        void Create(Projection Projection);
        void Delete(int id);
    }
}
