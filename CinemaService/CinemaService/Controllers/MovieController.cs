using CinemaService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaService.Controllers
{
    public class MovieController : ApiController
    {

        IMovieService service { get; set; }

        public MovieController(IMovieService service)
        {
            this.service = service;
        }

    }
}
