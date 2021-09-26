
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{


   public class ProjectionType
   {
      [Key]
      public int Id { get; set; }

      [Required]
      public string TypeName { get; set; }

      public ICollection<Theater> Theaters { get; set; }



   }
}