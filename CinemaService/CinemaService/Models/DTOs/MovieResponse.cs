using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Models.DTOs
{
    public class MovieResponse
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public int Duration { get; set; }

        public string Studio { get; set; }

        public string Country { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Actors { get; set; }
       
        public IEnumerable<string> Genres { get; set; }
    }
}