using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CinemaService.Repository
{
    public class ProjectionRepository : IProjectionRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public IQueryable<Projection> GetByDate(DateTime dateTime)
        {
            return db.Projections.Where(p => p.DateTimeShowing.Day.Equals(dateTime.Day));
        }



        
    }
}