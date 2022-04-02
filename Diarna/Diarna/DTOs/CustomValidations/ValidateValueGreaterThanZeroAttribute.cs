using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs.CustomValidations
{
    public class ValidateValueGreaterThanZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Convert.ToInt32(value) > 0 ? true : false;
        }
    }
}
