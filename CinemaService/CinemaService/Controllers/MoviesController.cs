using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;
using System.Net;
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

        [Authorize]
        [HttpPost]
        [Route("api/Filter")]
        public IEnumerable<MovieDTO> PostFilter(MovieFilter movieFilter)
        {
            return service.Filter(movieFilter);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(MovieRequest movieRequest)
        {
            if (User.IsInRole("Administrator"))
            {

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                service.Create(movieRequest);

                return Created("DefaultApi", movieRequest);
            }
            return Unauthorized();
           

        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Put(int id, MovieRequest movieRequest)
        {
            

            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (User.IsInRole("Administrator"))
            {

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
            return Unauthorized();
               
            
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (User.IsInRole("Administrator"))
            {
                service.Delete(id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            return Unauthorized();
        }


    }
}
