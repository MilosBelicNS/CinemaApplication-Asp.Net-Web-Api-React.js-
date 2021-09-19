
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public int SerialNumber { get; set; }


        public bool Free { get; set; }

        [Required]
        public Theater Theater { get; set; }

    }
}