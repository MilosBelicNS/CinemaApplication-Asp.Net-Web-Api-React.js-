using CinemaService.Models;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
    public interface IProjectionService
    {

        IEnumerable<ProjectionDTO> GetByDate(DateTime date);
       // IEnumerable<ProjectionDTO> GetAll();
        IEnumerable<ProjectionDTO> GetByFilter(ProjectionFilter projectionFilter);
        ProjectionById GetById(int id);
        void BuyTicket(ProjectionDTO projectionDTO, Ticket ticket);
        void Create(ProjectionRequest projectionRequest);
        void Delete(int id);
    }
}
