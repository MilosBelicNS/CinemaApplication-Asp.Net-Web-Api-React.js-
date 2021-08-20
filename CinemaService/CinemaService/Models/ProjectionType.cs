
using System.ComponentModel.DataAnnotations;


namespace CinemaService.Models
{

 
    public class ProjectionType
    {

        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

    }
}