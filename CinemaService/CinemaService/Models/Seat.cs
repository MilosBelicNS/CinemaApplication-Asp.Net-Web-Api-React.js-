
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CinemaService.Models
{
   public class Seat
   {
      [Key]
      public int Id { get; set; }
      public int SerialNumber { get; set; }
      public bool Free { get; set; }
     
      public Theater Theater { get; set; }

   }
}