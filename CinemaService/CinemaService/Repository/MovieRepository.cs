using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CinemaService.Repository
{
    public class MovieRepository : IMovieRepository, IDisposable
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        

        public Movie GetById(int id)
        {
            
            return db.Movies.Find(id);

        }

        public void Create(Movie movie)
        {
           
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)  
        {
           
            
            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
          
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);

            db.Movies.Remove(movie);
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