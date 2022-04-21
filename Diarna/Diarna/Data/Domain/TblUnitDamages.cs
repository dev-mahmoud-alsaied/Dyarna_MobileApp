using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblUnitDamages
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public decimal DamageAmount { get; set; }

        public int RentUserId { get; set; }
        public int UnitId { get; set; }
        public int ItemId { get; set; }
        public virtual TblItem Item { get; set; }
        public virtual TblUnit Unit { get; set; }
        public TblRentUser RentUser { get; set; }
    }
}
