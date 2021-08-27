using CinemaService.Models;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionService
    {

        IEnumerable<ProjectionDTO> GetByDate(DateTime date);//sve projekcije za tekuci datum
        IEnumerable<ProjectionDTO> GetByMovie(int movieId);//sve projekcije za dati film
        IEnumerable<ProjectionDTO> GetByFilter(ProjectionFilter projectionFilter);//projekcije po filteru
        ProjectionById GetById(int id);//projekcija po id
        
        void Create(ProjectionRequest projectionRequest);
        void Delete(int id);
    }
}
