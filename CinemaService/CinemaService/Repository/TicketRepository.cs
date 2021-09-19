using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaService.Repository
{
    public class TicketRepository : ITicketRepository, IDisposable
    {
        private ApplicationDbContext db;

        public TicketRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IEnumerable<Ticket> GetAll()
        {

            return db.Tickets;
        }

        public Ticket GetById(int id)
        {

            return db.Tickets.Find(id);

        }

        public void Create(Ticket ticket)
        {


            ticket.Seat = ticket.Projection.Theater.Seats
                                 .Where(x => x.Free == true)
                                 .First();




            ticket.Seat.Free = false;

            db.Tickets.Add(ticket);
            db.SaveChanges();

        }



        public void Delete(int id)
        {
            Ticket ticket = db.Tickets.Find(id);

            db.Tickets.Remove(ticket);
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}