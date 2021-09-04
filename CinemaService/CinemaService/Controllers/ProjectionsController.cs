using CinemaService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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






    }
}
