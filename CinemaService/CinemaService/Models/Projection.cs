
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinemaService.Models.Validations;

namespace CinemaService.Models
{
   public class Projection
   {

      [Key]
      public int Id { get; set; }

      [Required]
      [DataType(DataType.DateTime)]
      [CurrentDateTime(ErrorMessage = "Showing date must be in future!")]
      public DateTime DateTimeShowing { get; set; }

      [Required]
      [Range(1, maximum: 100)]
      public decimal TicketPrice { get; set; }

      [Required]
      public Movie Movie { get; set; }

      [Required]
      public ProjectionType ProjectionType { get; set; }
      [Required]
      public Theater Theater { get; set; }

      public User Admin { get; set; }

      public bool Deleted { get; set; }
      public bool SoldOut { get; set; }
      [NotMapped]
      public DateTime? EndOfProjection { get; set; }

      public virtual ICollection<Ticket> Tickets { get; set; }

     

   }
}