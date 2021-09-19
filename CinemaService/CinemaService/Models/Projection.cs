﻿
using CinemaService.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class Projection
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [CurrentDateTime(ErrorMessage = "Showing date must be in future!")]
        public DateTime DateTimeShowing { get; set; }

        [Required]
        [Range(1, maximum:100)]
        public decimal TicketPrice { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public ProjectionType ProjectionType { get; set; }
        [Required]
        public Theater Theater { get; set; }
        
        public User Admin { get; set; }

        public bool Deleted { get; set; }
        public bool SoldOut { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }

    }
}