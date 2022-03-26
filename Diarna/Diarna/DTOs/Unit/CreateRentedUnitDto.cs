using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs.Unit
{
    public class CreateRentedUnitDto
    {
        [Required]
        public DateTime? RentStartDate { get; set; }
        [Required]
        public DateTime? RentEndDate { get; set; }
        [Required]
        public decimal? DeliveryPrice { get; set; }
        public string Remarks { get; set; }
        [Required]
        public int? UnitId { get; set; }
    }
}
