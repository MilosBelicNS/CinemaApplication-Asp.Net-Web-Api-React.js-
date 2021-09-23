using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
   public class Ticket
   {
      [Key]
      public int Id { get; set; }

      [Required]
      public DateTime DatePurchased { get; set; }

      [Required]
      public virtual Projection Projection { get; set; }

      public virtual Seat Seat { get; set; }

      public virtual User Customer { get; set; }



   }
}