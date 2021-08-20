using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionService
    {

        IEnumerable<ProjectionDTO> GetByDate(string date);
        IEnumerable<ProjectionDTO> GetByFilter(ProjectionFilter projectionFilter);
        ProjectionById GetById(int id);
        void Create(ProjectionRequest projectionRequest);
        void Delete(int id);
    }
}
