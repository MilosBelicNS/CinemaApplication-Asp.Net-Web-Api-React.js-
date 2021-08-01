using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CinemaService.Models
{

   public enum Name 
    {
        [Description("2D")]
        Type_2D,
        [Description("3D")]
        Type_3D,
        [Description("4D")]
        Type_4D }
    public class ProjectionType
    {

        public int Id { get; set; }
        public Name TypeName { get; set; }

    }
}