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

        public IQueryable<Movie> GetByFilter(MovieFilter movieFilter)
        {
            IQueryable<Movie> movies = Enumerable.Empty<Movie>().AsQueryable();
            

            if (movieFilter.Name != null & movieFilter.Name != "")
            {
                movies = db.Movies.Where(n => n.Name.Contains(movieFilter.Name));
            }

            if (movieFilter.DurationStart != null & movieFilter.DurationStart != 0 && movieFilter.DurationStop != null & movieFilter.DurationStop != 0)
            {
                movies = db.Movies.Where(x => x.Duration >= movieFilter.DurationStart && x.Duration <= movieFilter.DurationStop);
            }

            if (movieFilter.Genre != null & movieFilter.Genre != "")
            {
                movies = db.Movies.Where(x => x.Genres.Contains(movieFilter.Genre));
            }

            if (movieFilter.Country != null & movieFilter.Country != "")
            {
                movies = db.Movies.Where(x => x.Country.Contains(movieFilter.Country));
            }

            if (movieFilter.StartYear != null & movieFilter.StartYear != 0 && movieFilter.EndYear != null & movieFilter.EndYear != 0)
            {
                movies = db.Movies.Where(x => x.Year >= movieFilter.StartYear && x.Year <= movieFilter.EndYear);
            }

            if (movieFilter.OrderBy == "Name")
            {
                movies = db.Movies.OrderBy(x => x.Name);
            }

            if (movieFilter.OrderBy == "NameDesc")
            {
                movies = db.Movies.OrderByDescending(x => x.Name);
            }

            if (movieFilter.OrderBy == "Duration")
            {
                movies = db.Movies.OrderBy(x => x.Duration);
            }

            if (movieFilter.OrderBy == "DurationDesc")
            {
                movies = db.Movies.OrderByDescending(x => x.Duration);
            }

            if (movieFilter.OrderBy == "Country")
            {
                movies = db.Movies.OrderBy(x => x.Country);
            }

            if (movieFilter.OrderBy == "CountryDesc")
            {
                movies = db.Movies.OrderByDescending(x => x.Country);
            }

            if (movieFilter.OrderBy == "Year")
            {
                movies = db.Movies.OrderBy(x => x.Year);
            }

            if (movieFilter.OrderBy == "YearDesc")
            {
                movies = db.Movies.OrderByDescending(x => x.Year);
            }

            return movies;

        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Create(Movie movie)
        {
            //var id = db.Movies.Max(x => x.Id);

            //movie.Id = id + 1; za servis

            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)  
        {
           
            //var toUpdate = db.Movies.Find(
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