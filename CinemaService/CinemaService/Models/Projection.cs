
using CinemaService.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaService.Models
{
    public class Projection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [CurrentDateTime(ErrorMessage = "Showing date must be in future!")]
        public DateTime DateTimeShowing { get; set; }

        [Required]
        [Range(1, maximum:1000)]
        public decimal TicketPrice { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public ProjectionType ProjectionType { get; set; }
        [Required]
        public Theater Theater { get; set; }

        public User Admin { get; set; }
        [ForeignKey("Admin")]
        public string AdminId { get; set; }
    }
}