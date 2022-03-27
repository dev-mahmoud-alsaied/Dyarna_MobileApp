using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs
{
    public class CreateRentExpensesDto
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        [Required]
        public decimal? ItemValue { get; set; }
        [Required]
        public int UnitId { get; set; }
        //public int? SharesId { get; set; }
    }
}
