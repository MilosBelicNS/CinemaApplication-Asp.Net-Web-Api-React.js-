using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaService.Repository
{
    public class MovieRepository : IMovieRepository, IDisposable
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public IEnumerable<Movie> GetByFilter(MovieFilter movieFilter)
        {
            IEnumerable<Movie> movies = db.Movies;

            if (movieFilter.Name != null & movieFilter.Name != "")
            {
                movies = movies.Where(n => n.Name.Contains(movieFilter.Name));
            }

            if (movieFilter.DurationStart != null  & movieFilter.DurationStart != 0 && movieFilter.DurationStop != null & movieFilter.DurationStop != 0)
            {
                movies= movies.Where(x => x.Duration >= movieFilter.DurationStart && x.Duration <= movieFilter.DurationStop);
            }

            if (movieFilter.Genre != null & movieFilter.Genre != "")
            {
                movies = movies.Where(x => x.Genres.Contains(movieFilter.Genre));
            }

            if (movieFilter.Country != null & movieFilter.Country != "")
            {
                movies = movies.Where(x => x.Country.Contains(movieFilter.Country));
            }

            if (movieFilter.StartYear != null & movieFilter.StartYear != 0 && movieFilter.EndYear != null & movieFilter.EndYear != 0)
            {
                movies = movies.Where(x => x.Year >= movieFilter.StartYear && x.Year <= movieFilter.EndYear );
            }

            if (movieFilter.OrderBy == "Name")
            {
                movies = movies.OrderBy(x => x.Name);
            }

            if (movieFilter.OrderBy == "NameDesc")
            {
                movies = movies.OrderByDescending(x => x.Name);
            }

            if (movieFilter.OrderBy == "Duration")
            {
                movies = movies.OrderBy(x => x.Duration);
            }

            if (movieFilter.OrderBy == "DurationDesc")
            {
                movies = movies.OrderByDescending(x => x.Duration);
            }

            if (movieFilter.OrderBy == "Country")
            {
                movies = movies.OrderBy(x => x.Country);
            }

            if (movieFilter.OrderBy == "CountryDesc")
            {
                movies = movies.OrderByDescending(x => x.Country);
            }

            if (movieFilter.OrderBy == "Year")
            {
                movies = movies.OrderBy(x => x.Year);
            }

            if (movieFilter.OrderBy == "YearDesc")
            {
                movies = movies.OrderByDescending(x => x.Year);
            }

            return movies;

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