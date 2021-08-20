using System;
using System.ComponentModel.DataAnnotations;
namespace CinemaService.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public bool Purchased { get; set; }

        [Required]
        public DateTime DatePurchased { get; set; }

        [Required]
        public Projection Projection { get; set; }
        public Seat Seat { get; set; }
        [Required]
        public User User { get; set; }

    }
}