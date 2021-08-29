using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Models.DTOs
{
    public class TicketDTO
    {

        public DateTime DatePurchased { get; set; }

        public User Customer { get; set; }


    }
}