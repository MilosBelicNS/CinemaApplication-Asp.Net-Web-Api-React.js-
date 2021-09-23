using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CinemaService.Interfaces;
using CinemaService.Models;

namespace CinemaService.Repository
{
   public class ProjectionRepository : IProjectionRepository, IDisposable
   {



      private ApplicationDbContext db;

      public ProjectionRepository(ApplicationDbContext db)
      {
         this.db = db;
      }


      public IEnumerable<Projection> GetAll()
      {

         return db.Projections.Include(x => x.Movie)
                              .Include(x => x.ProjectionType)
                              .Include(x => x.Theater)
                              .Include(x => x.Admin);


      }

      public Projection GetById(int id)
      {

         Projection projection = db.Projections.Include(x => x.Movie)
                              .Include(x => x.ProjectionType)
                              .Include(x => x.Theater)
                              .Include(x => x.Admin)
                              .Where(x => x.Id == id)
                              .FirstOrDefault();
         return projection;
      }

      public void Create(Projection projection)
      {

         db.Projections.Add(projection);
         db.SaveChanges();
      }

      public void Delete(int id)
      {
         Projection projection = db.Projections.Find(id);

         db.Projections.Remove(projection);
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