
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

        [Required]
        [Range(1,int.MaxValue)]
        public int TicketPrice { get; set; }


        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public ProjectionType Type { get; set; }
        [ForeignKey("ProjectionType")]
        public int ProjectionTypeId { get; set; }

        public Theater Theater { get; set; }
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }

        public Admin Admin { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
    }
}