using System.Collections.Generic;
using CinemaService.Models;

namespace CinemaService.DTOs
{
   public class TheaterResponse
   {

      public int Id { get; set; }
      public string Name { get; set; }
      public bool Free { get; set; }
      public  ICollection<Seat> Seats { get; set; }
      public  ICollection<ProjectionTypeResponse> ProjectionTypes { get; set; }

   }
}