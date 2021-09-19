using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaService.Interfaces
{
    public interface ITicketRepository
    {

        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        void Create(Ticket ticket);
        void Delete(int id);
    }
}
