using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblMonthlyFiltring
    {
        public int UnitId { get; set; }
        public DateTime Date { get; set; }
        public decimal? Value { get; set; }

        public virtual TblUnit Unit { get; set; }
    }
}
