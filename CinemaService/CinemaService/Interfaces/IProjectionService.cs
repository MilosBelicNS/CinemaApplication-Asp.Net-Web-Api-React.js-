using CinemaService.DTOs;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionService
    {

        IEnumerable<ProjectionResponse> GetByDate(DateTime date);//sve projekcije za tekuci datum
        IEnumerable<ProjectionResponse> Filter(ProjectionFilter projectionFilter);//sve projekcije za dati film

        ProjectionById GetById(int id);
        
        void Create(ProjectionRequest projectionRequest);
        void Delete(int id);
    }
}
