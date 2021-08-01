using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{
    public class Seat
    {
        [Key]
        public int SerialNumber { get; set; }

        [Required]
        public bool Free { get; set; }

        public Theater Theater { get; set; }
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }


    }
}