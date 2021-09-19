using CinemaService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.DTOs
{
    public class TicketRequest
    {



        [Required]
        public DateTime DatePurchased { get; set; }

        [Required]
        public Projection Projection { get; set; }

        [Required]
        public Seat Seat { get; set; }
        [Required]
        public User Customer { get; set; }
        public int NumberOfTickets { get; set; }
        

    }
}