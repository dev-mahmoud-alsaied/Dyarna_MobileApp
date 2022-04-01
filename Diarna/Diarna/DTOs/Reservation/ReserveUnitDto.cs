using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.CustomValidations;

namespace Diarna.DTOs.Rerservation
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveUnitDto
    {
        [Required(ErrorMessage = "الوحده مطلوبه")]
        [ValidateValueGreaterThanZero(ErrorMessage = "رقم الوحده غير صحيح")]
        public int UnitId { get; set; }
        
        [Required(ErrorMessage = "اسم المستأجر مطلوب")]
        public string RentUserName { get; set; }
        
        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "عذا رقم هاتف غير صحيح")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "قيمة التأمين")]
        [ValidateValueGreaterThanZero(ErrorMessage = "قيمه التأمين يجب ان تكون اكبر من صفر")]
        public decimal? InsuranceValue { get; set; }

        [Required(ErrorMessage = "قيمه الإيجار مطلوبه")]
        [ValidateValueGreaterThanZero(ErrorMessage = "القيمه الكليه للأيجار يجب أن تكون أكبر من صفر")]
        public decimal? TotalValue { get; set; }

        [Required(ErrorMessage = "قيمة تأكيد الحجز")]
        [ValidateValueGreaterThanZero(ErrorMessage = "قيمه تأكيد الحجز يجب أن تكون أكبر من صفر")]
        public decimal? DepositValue { get; set; }

        [Required(ErrorMessage = "تاريخ بدايه الحجز مطلوب")] 
        [ValidateDate("EndDate", ErrorMessage = "لابد ان يكون التاريخ النهائي اكبر من الابتدائي")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "تاريخ نهاية الحجز مطلوب")]
        public DateTime EndDate { get; set; }


    }
}
