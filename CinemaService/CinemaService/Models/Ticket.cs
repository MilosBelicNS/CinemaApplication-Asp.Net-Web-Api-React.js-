using CinemaService.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaService.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool Purchased { get; set; }

        [Required]
        
        public DateTime DatePurchased { get; set; }

        [Required]
        public Projection Projection { get; set; }
        
        public Seat Seat { get; set; }
       
        public User Customer { get; set; }

    }
}