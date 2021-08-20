

namespace CinemaService.Models
{
    public class MovieFilter
    {

        public string Name { get; set; }

        public int? DurationStart { get; set; }

        public int? DurationStop { get; set; }

        public string Genre { get; set; }

        public string Country { get; set; }

        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string OrderBy { get; set; }
    }
}