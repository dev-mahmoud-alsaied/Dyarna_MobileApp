using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblRentedUnit
    {
        public int Id { get; set; }
        public DateTime? RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public string Remarks { get; set; }
        public int? UnitId { get; set; }

        public virtual TblUnit Unit { get; set; }
    }
}
