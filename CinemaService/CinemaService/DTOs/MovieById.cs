using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.DTOs
{
    public class MovieById
    {

        public string Name { get; set; }


        public string Director { get; set; }


        public int Duration { get; set; }

        public string PicturePath { get; set; }


        public string Studio { get; set; }


        public string Country { get; set; }

        public int Year { get; set; }


        public string Description { get; set; }

        public string Genre { get; set; }

        public bool Deleted { get; set; }

        public List<string> Actors { get; set; }

        public virtual IEnumerable<ProjectionResponse> Projections { get; set; }
    }
}