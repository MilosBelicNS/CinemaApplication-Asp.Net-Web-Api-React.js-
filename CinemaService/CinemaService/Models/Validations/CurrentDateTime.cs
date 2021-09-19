using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaService.Models.Validations
{
    public class CurrentDateTime : ValidationAttribute
    {

        public CurrentDateTime()
        {

        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}