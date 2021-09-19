using System;

namespace CinemaService.Models.DTOs
{
    public class TicketDtoAdmin
    {

        public DateTime DatePurchased { get; set; }

        public User Customer { get; set; }


    }
}