using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblReservation
    {
        public int UnitId { get; set; }
        public int? RentUserId { get; set; }
        public int DateId { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? DepositValue { get; set; }
        public string Remarks { get; set; }
        public byte? ConfirmReservation { get; set; }

        public virtual TblReservationDate Date { get; set; }
        public virtual TblRentUser RentUser { get; set; }
        public virtual TblUnit Unit { get; set; }
    }
}
