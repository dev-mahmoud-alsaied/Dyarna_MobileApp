using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblUnitsShare
    {
        public int UnitId { get; set; }
        public int Year { get; set; }
        public int SharesId { get; set; }

        public virtual TblShare Shares { get; set; }
        public virtual TblUnit Unit { get; set; }
    }
}
