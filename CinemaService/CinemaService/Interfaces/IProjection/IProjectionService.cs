using CinemaService.DTOs;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionService
    {
        IEnumerable<ProjectionResponse> GetAll();
        IEnumerable<ProjectionResponse> GetByDate(DateTime date);
        IEnumerable<ProjectionResponse> Filter(ProjectionFilter projectionFilter);
        IEnumerable<ProjectionResponse> GetByMovieId(int movieId, string sortType);
        ProjectionById GetById(int id);
        void Create(ProjectionRequest projectionRequest);
        void Delete(int id);
    }
}
