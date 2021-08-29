
using System.Collections.Generic;


namespace CinemaService.Models.DTOs
{
    public class MovieDTO
    {

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Studio { get; set; }

        public string Country { get; set; }

        public int Year { get; set; }

        public List<string> Genres { get; set; }
    }
}
