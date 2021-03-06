using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Rerservation
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadReservationDto
    {

        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? RentUserId { get; set; }
        public string RentUserName { get; set; }
        public int DateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? DepositValue { get; set; }
        public string Remarks { get; set; }
        public byte? ConfirmReservation { get; set; }

    }
}
