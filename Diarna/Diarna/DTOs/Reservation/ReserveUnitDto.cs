using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Rerservation
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveUnitDto
    {
        public int UnitId { get; set; }
        public string RentUserName { get; set; }
        public string Mobile { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? DepositValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
