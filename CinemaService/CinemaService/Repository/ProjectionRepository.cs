using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace CinemaService.Repository
{
    public class ProjectionRepository : IProjectionRepository, IDisposable
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Projection> GetAll()
        {
            
            return db.Projections.Include(p => p.Movie);
        }

        public Projection GetById(int id)
        {

            return db.Projections.Find(id);

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