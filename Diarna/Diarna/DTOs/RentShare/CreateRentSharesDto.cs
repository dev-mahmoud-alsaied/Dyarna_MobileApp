using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.RentShare
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateRentSharesDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? UserSharesId { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public decimal? UserCash { get; set; }
        [Required]
        public double? Percent { get; set; }
        public double? ManagePercent { get; set; }
        [Required]
        public decimal? UserMinProfit { get; set; }
        public decimal? AdditionProfit { get; set; }
        [Required]
        public byte? ShareType { get; set; }
    }
}
