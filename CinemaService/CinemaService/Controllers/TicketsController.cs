using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Models.DTOs;

namespace CinemaService.Controllers
{
   [RoutePrefix("api/Tickets")]
   public class TicketsController : ApiController
   {
      private ITicketService service;

      public TicketsController(ITicketService service)
      {
         this.service = service;
      }

      [HttpGet()]
      public IEnumerable<TicketDtoAdmin> GetByProjectionId(int projectionId, string sortType)
      {
         return service.GetByProjectionId(projectionId, sortType);
      }

      [HttpGet()]
      [Route("{id:int}")]
      [ResponseType(typeof(TicketById))]
      public IHttpActionResult GetById(int id)
      {
         var ticket = service.GetById(id);

         if (ticket == null)
         {
            return NotFound();
         }
         return Ok(ticket);

      }

      [HttpPost()]
      public IHttpActionResult Create(TicketRequest ticketRequest)
      {
         if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

         try
         {
            service.Create(ticketRequest);
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }


         return Created("DefaultApi", ticketRequest);

      }

      [HttpDelete()]
      [Route("{id:int}")]
      public IHttpActionResult Delete(int id)
      {
         var ticket = service.GetById(id);

         if (ticket == null)
         {
            return NotFound();
         }

         service.Delete(id);

         return StatusCode(HttpStatusCode.NoContent);
      }



   }
}
