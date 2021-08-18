using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Models.DTOs
{
    public class MovieDTO
    {

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Studio { get; set; }

        public string Country { get; set; }

        public int Year { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}
