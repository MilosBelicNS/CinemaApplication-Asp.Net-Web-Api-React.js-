using CinemaService.Models;
using System.Collections.Generic;

namespace CinemaService.Interfaces.IProjectionType
{
   public interface IProjectionTypeRepository
   {

      IEnumerable<ProjectionType> GetAll();
      ProjectionType GetById(int id);
   }
}
