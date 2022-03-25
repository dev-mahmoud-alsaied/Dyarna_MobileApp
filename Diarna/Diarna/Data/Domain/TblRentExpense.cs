using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblRentExpense
    {
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public decimal? ItemValue { get; set; }
        public int UnitId { get; set; }
        public int? SharesId { get; set; }

        public virtual TblItem Item { get; set; }
        public virtual TblShare Shares { get; set; }
        public virtual TblUnit Unit { get; set; }
    }
}
