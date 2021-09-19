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
        




    }
}
