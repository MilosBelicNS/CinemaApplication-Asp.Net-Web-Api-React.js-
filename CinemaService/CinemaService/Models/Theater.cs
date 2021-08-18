using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{

    
    public class Theater
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Free { get; set; }

        public virtual List<ProjectionType> ProjectionTypes { get; set; }
        public virtual List<Seat> Seats { get; set; }
    }
}