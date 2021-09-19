using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{

    public class Theater
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Free { get; set; }

        public IEnumerable<Seat> Seats { get; set; }
        public ICollection<ProjectionType> ProjectionTypes { get; set; }



        public Theater()
        {
            this.ProjectionTypes = new HashSet<ProjectionType>();

        }




    }
}