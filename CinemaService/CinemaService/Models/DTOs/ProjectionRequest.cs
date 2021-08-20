using CinemaService.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;


namespace CinemaService.Models.DTOs
{
    public class ProjectionRequest
    {
        [Required]
        [DataType(DataType.DateTime)]
        [CurrentDateTime(ErrorMessage = "Showing date must be in future!")]
        public DateTime DateTimeShowing { get; set; }

        [Required]
        [Range(1, maximum: 1000)]
        public decimal TicketPrice { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public ProjectionType ProjectionType { get; set; }

        [Required]
        public Theater Theater { get; set; }
       

        [Required]
        public User User { get; set; }
        
    }
}