
using CinemaService.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{
    public class Projection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [CurrentDateTime(ErrorMessage = "Showing date must be in future!")]
        public DateTime DateTimeShowing { get; set; }


        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public ProjectionType ProjectionType { get; set; }
        [ForeignKey("ProjectionType")]
        public int ProjectionTypeId { get; set; }

        public Theater Theater { get; set; }
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public  string UserId { get; set; }
    }
}