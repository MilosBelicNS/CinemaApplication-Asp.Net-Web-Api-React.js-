using System;


namespace CinemaService.Models.DTOs
{
    public class ProjectionById
    {

        public string MovieName { get; set; }
        public DateTime DateTimeShowing { get; set; }
        public ProjectionType ProjectionType { get; set; }
        public Theater Theater { get; set; }
        public decimal TicketPrice { get; set; }
        public int FreeSeats { get; set; }
    }
}