using System.Collections.Generic;
using CinemaService.Models;

namespace CinemaService.DTOs
{
   public class ProjectionTypeResponse
   {
      public int Id { get; set; }
      public string TypeName { get; set; }
      public ICollection<TheaterResponse> Theaters { get; set; }
   }
}