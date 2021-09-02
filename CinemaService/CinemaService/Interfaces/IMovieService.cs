﻿using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;


namespace CinemaService.Interfaces
{
   public interface IMovieService
    {
        IEnumerable<MovieResponse> GetAll();
        IEnumerable<MovieDTO> Filter(MovieFilter movieFilter);
        MovieResponse GetById(int id);
        void Create(MovieRequest movieRequest);
        void Update(int id, MovieRequest movieRequest);
        void Delete(int id);//samo logicko brisanje treba da postoji 
    }
}
