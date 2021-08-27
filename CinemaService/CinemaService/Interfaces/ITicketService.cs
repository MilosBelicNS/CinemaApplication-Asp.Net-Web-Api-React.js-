using CinemaService.Models;
using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaService.Interfaces
{
    public interface ITicketService
    {

        IEnumerable<TicketDTO> GetAll(Object obj, string sortType);//sve kupljene karte, parametri za sortiranje
        TicketById GetById(int id);
        void BuyTicket(ProjectionDTO projectionDTO, Ticket ticket);
        void Delete(int id); // samo administrator i samo ako nije u proslosti

    }
}
