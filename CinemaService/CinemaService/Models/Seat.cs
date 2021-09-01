
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaService.Models
{
    public class Seat
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int SerialNumber { get; set; }

        
        public bool Free { get; set; }

        [Required]
        public Theater Theater { get; set; }

    }
}