using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Models.DTOs
{
    public class TicketById
    {

        public string MovieName { get; set; }
        public DateTime DateTimeShowing { get; set; }
        public ProjectionType ProjectionType { get; set; }
        public Theater Theater { get; set; }
        public Seat Seat { get; set; }
        public decimal TicketPrice { get; set; }
    }
}