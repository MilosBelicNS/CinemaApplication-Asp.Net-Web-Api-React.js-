using System.Collections.Generic;
using CinemaService.DTOs;

namespace CinemaService.Interfaces.IProjectionType
{
   public interface IProjectionTypeService
   {
      IEnumerable<ProjectionTypeResponse> GetAll();
      ProjectionTypeResponse GetById(int id);
   }
}
