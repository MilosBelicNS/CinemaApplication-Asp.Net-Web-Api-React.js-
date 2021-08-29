using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public Guid Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Director { get; set; }

        [Required]
        [Range(1, 300)]
        public int Duration { get; set; }

        public string PicturePath { get; set; }

        [Required]
        [StringLength(50)]
        public string Studio { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [Range(1950, 2021)]
        public int Year { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public bool Deleted { get; set; }




        public List<string> Actors { get; set; }
       
        public List<string> Genres { get; set; }


    }
}