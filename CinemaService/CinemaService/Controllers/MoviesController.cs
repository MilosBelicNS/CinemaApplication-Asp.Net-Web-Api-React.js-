using AutoMapper;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CinemaService.Controllers
{
    public class MoviesController : ApiController
    {

        
        IMovieService service { get; set; }

        public MoviesController(IMovieService movieService)
        {
           
            this.service = movieService;
        }

        [HttpGet()]
        public IEnumerable<MovieResponse> GetAll()
        {
            return service.GetAll();

        }

        [HttpPost]
        [Route("api/Filter")]
        public IEnumerable<MovieDTO> PostFilter(MovieFilter movieFilter)
        {
            return service.GetByFilter(movieFilter);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(MovieResponse))]
        public IHttpActionResult GetById(int id)
        {
            var movie = service.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]MovieRequest movieRequest)
        {
              if (!ModelState.IsValid)
              return BadRequest("Invalid data.");

              service.Create(movieRequest);

              return Created("DefaultApi", movieRequest);


        }

        [HttpPut]
        public IHttpActionResult Put(int id, MovieRequest movieRequest)
        {
            

            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            

            try
            {
                service.Update(id, movieRequest);
            }
            catch
            {
                return Conflict();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           
            service.Delete(id);
            
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
