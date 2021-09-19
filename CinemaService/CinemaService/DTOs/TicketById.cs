using System;

namespace CinemaService.Models.DTOs
{
    public class TicketById
    {

        public Movie Movie { get; set; }
        public DateTime DateTimeShowing { get; set; }
        public ProjectionType ProjectionType { get; set; }
        public Theater Theater { get; set; }
        public Seat Seat { get; set; }
        public decimal TicketPrice { get; set; }
        public User Customer { get; set; }
    }
}