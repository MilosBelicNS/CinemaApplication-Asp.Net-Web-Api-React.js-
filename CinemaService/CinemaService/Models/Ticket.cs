using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DatePurchased { get; set; }


        public Projection Projection { get; set; }
        [ForeignKey("Projection")]
        public int ProjectionId { get; set; }

        public Seat Seat { get; set; }
        [ForeignKey("Seat")]
        public int SeatId { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}