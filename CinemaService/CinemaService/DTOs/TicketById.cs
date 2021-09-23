using System;

namespace CinemaService.Models.DTOs
{
   public class TicketById
   {



      public Projection Projection { get; set; }
      public Seat Seat { get; set; }
      public decimal TicketPrice { get; set; }
      public DateTime DatePurchased { get; set; }
   }
}