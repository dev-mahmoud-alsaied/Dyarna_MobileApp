using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.CustomValidations
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        private readonly string comparsionAtrr;

        public ValidateDateAttribute(string comparsionAtrr)
        {
            this.comparsionAtrr = comparsionAtrr;
        }
        /// <summary>
        /// التحقق من التاريخ الابتدائي والنهائي  
        /// وتوضع فوق التاريخ الابتدائي
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>check of two dates</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string msg =  ErrorMessageString;
            var startDate = ((DateTime) value).ToShortDateString();
            var property =  validationContext.ObjectType.GetProperty(comparsionAtrr);
            if (property == null)
                return new ValidationResult(ErrorMessage = "لابد ان تقوم بإداخل التاريخ النهائي");

            var endDate = ((DateTime)property.GetValue(validationContext.ObjectInstance)).ToShortDateString();
            if (DateTime.Compare(DateTime.Parse(startDate), DateTime.Parse(endDate)) > 0)
                return new ValidationResult(ErrorMessage = msg); // "لابد ان يكون التاريخ النهائي اكبر من الابتدائي");

            return ValidationResult.Success;
        }
    }
}
