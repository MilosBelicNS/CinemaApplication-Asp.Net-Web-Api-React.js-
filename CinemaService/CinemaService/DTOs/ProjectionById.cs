﻿using CinemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.DTOs
{
    public class ProjectionById
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateTimeShowing { get; set; }

        public decimal TicketPrice { get; set; }

        public ProjectionType ProjectionType { get; set; }
        public Theater Theater { get; set; }

        public int FreeSeats { get; set; }
    }
}