using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class User : ApplicationUser
    {
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}