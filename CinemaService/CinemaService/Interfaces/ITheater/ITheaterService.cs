using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaService.DTOs;
using CinemaService.Models;

namespace CinemaService.Interfaces.ITheater
{
   public interface ITheaterService
   {
      IEnumerable<TheaterResponse> GetAll();
      TheaterResponse GetById(int id);
   }
}
