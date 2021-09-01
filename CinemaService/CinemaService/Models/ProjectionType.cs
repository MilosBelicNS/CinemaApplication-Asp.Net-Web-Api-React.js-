
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaService.Models
{

 
    public class ProjectionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<Theater> Theaters { get; set; }


        public ProjectionType()
        {
            this.Theaters = new HashSet<Theater>();

        }
    }
}