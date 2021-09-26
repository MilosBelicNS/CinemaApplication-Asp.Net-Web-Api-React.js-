using System;
using System.Collections.Generic;
using CinemaService.Interfaces.IProjectionType;
using CinemaService.Models;

namespace CinemaService.Repository
{
   public class ProjectionTypeRepository : IProjectionTypeRepository, IDisposable
   {
      private ApplicationDbContext db;

      public ProjectionTypeRepository(ApplicationDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<ProjectionType> GetAll()
      {
         return db.ProjectionTypes;
      }


      public ProjectionType GetById(int id)
      {
         return db.ProjectionTypes.Find(id);
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