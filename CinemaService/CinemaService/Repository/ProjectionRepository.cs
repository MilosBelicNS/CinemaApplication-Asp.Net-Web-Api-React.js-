using CinemaService.Interfaces;
using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Repository
{
    public class ProjectionRepository : IProjectionRepository, IDisposable
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Projection> GetByDate(DateTime dateTime)
        {
            return db.Projections.Where(p => p.DateTimeShowing.Day.Equals(dateTime.Day));
        }


    }
}