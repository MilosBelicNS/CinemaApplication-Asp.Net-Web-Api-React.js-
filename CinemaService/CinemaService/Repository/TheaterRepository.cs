using System;
using System.Collections.Generic;
using CinemaService.Interfaces.ITheater;
using CinemaService.Models;

namespace CinemaService.Repository
{
   public class TheaterRepository : ITheaterRepository, IDisposable
   {

      private ApplicationDbContext db;

      public TheaterRepository(ApplicationDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<Theater> GetAll()
      {
         return db.Theaters;
      }


      public Theater GetById(int id)
      {
         return db.Theaters.Find(id);
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