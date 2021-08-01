using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{
   
    public class Admin : ApplicationUser
    {
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }
        

    }
}