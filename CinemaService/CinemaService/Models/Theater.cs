using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaService.Models
{

    public class Theater
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Free { get; set; }

       
        public  virtual ICollection<ProjectionType> ProjectionTypes { get; set; }
        


        public Theater()
        {
            this.ProjectionTypes = new HashSet<ProjectionType>();
            
        }

      

        
    }
}