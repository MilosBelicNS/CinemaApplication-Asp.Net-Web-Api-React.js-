﻿using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

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

            return db.Projections.Include(x => x.Tickets);
        }

        public Projection GetById(int id)
        {

            return db.Projections.Include(x => x.Tickets)
                                 .Where(x => x.Id == id)
                                 .FirstOrDefault();

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