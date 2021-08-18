using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{

 
    public class ProjectionType
    {

        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

    }
}