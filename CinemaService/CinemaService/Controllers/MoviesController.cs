using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CinemaService.Controllers
{
    [RoutePrefix("api/Movies")]
    public class MoviesController : ApiController
    {

        IMovieService service { get; set; }

        public MoviesController(IMovieService service)
        {

            this.service = service;
        }

        [HttpGet()]
        public IEnumerable<MovieResponse> GetAll()
        {
            return service.GetAll();

        }

        [Authorize]
        [HttpPost()]
        [Route("FilterSort")]
        public IEnumerable<MovieResponse> PostFilter(MovieFilter movieFilter)
        {
            return service.Filter(movieFilter);
        }

        [Authorize]
        [HttpGet()]
        [Route("{id:int}")]
        [ResponseType(typeof(MovieById))]
        public IHttpActionResult GetById(int id)
        {
            var movie = service.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost()]
        public IHttpActionResult Post(MovieRequest movieRequest)
        {


            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            service.Create(movieRequest);

            return Created("DefaultApi", movieRequest);



        }

        [Authorize(Roles = "Administrator")]
        [HttpPut()]
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

        [Authorize(Roles = "Administrator")]
        [HttpDelete()]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {

            service.Delete(id);

            return StatusCode(HttpStatusCode.NoContent);

        }


    }
}
