using System;
using System.Collections.Generic;
using CinemaService.Interfaces;
using CinemaService.Models;
using System.Data.Entity;
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

        
         Ticket ticket = db.Tickets.Include(x =>x.Projection.Movie).Where(x=>x.Id == id).FirstOrDefault();
         return ticket;
      }

      public void Create(Ticket ticket)
      {


         if (ticket.Projection.Theater.Free == false)
         {
            ticket.Projection.SoldOut = true;
         }

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