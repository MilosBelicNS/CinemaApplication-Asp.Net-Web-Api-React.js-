using System;


namespace CinemaService.Models.Filters
{
    public class ProjectionFilter
    {

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
        public string  MovieName { get; set; }
        public int OrderBy { get; set; }

        public string ProjectionType { get; set; }
        public string Theatar { get; set; }

    }
}