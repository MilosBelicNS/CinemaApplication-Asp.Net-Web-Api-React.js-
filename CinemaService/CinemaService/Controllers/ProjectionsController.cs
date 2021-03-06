using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CinemaService.Interfaces;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;

namespace CinemaService.Controllers
{
   [RoutePrefix("api/Projections")]
   public class ProjectionsController : ApiController
   {

      IProjectionService service { get; set; }

      public ProjectionsController(IProjectionService service)
      {

         this.service = service;
      }

      [HttpGet()]
      public IEnumerable<ProjectionResponse> GetAll()
      {
         return service.GetAll();

      }


      [Authorize]
      [HttpGet()]
      [Route("CurrentDate")]
      public IEnumerable<ProjectionResponse> GetByDate(DateTime dateTime)
      {
         return service.GetByDate(dateTime);
      }

      [Authorize]
      [HttpPost()]
      [Route("FilterSort")]
      public IEnumerable<ProjectionResponse> PostFilter(ProjectionFilter projectionFilter)
      {
         return service.Filter(projectionFilter);
      }

      [Authorize]
      [HttpGet()]
      [Route("{id:int}")]
      [ResponseType(typeof(ProjectionResponse))]
      public IHttpActionResult GetById(int id)
      {
         var projection = service.GetById(id);

         if (projection == null)
         {
            return NotFound();
         }
         return Ok(projection);
      }

    //  [Authorize(Roles = "Administrator")]
      [HttpPost()]
      public IHttpActionResult Post(ProjectionRequest projectionRequest)
      {
         

         if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

         try
         {
            service.Create(projectionRequest);
         }
         catch(Exception e)
         {
            return BadRequest(e.Message);
         }

        

         return Created("DefaultApi", projectionRequest);

      }



      [Authorize(Roles = "Administrator")]
      [HttpDelete()]
      [Route("{id:int}")]
      public IHttpActionResult Delete(int id)
      {

         var projection = service.GetById(id);

         if (projection == null)
         {
            return NotFound();
         }

         service.Delete(id);

         return StatusCode(HttpStatusCode.NoContent);

      }






   }
}
