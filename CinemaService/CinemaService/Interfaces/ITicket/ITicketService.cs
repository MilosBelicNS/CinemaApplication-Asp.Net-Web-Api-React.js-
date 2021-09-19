using CinemaService.DTOs;
using CinemaService.Models.DTOs;
using System.Collections.Generic;

namespace CinemaService.Interfaces
{
    public interface ITicketService
    {

        IEnumerable<TicketDtoAdmin> GetByProjectionId(int projectionId, string sortType);
        TicketById GetById(int id);
        void Delete(int id);
        void Create(TicketRequest ticketRequest);

    }
}
