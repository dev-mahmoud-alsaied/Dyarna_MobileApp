using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Rerservation
{
    public class ReadReservationDto
    {

        public int UnitId { get; set; }
        public int? RentUserId { get; set; }
        public int DateId { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? DepositValue { get; set; }
        public string Remarks { get; set; }
        public byte? ConfirmReservation { get; set; }

    }
}
