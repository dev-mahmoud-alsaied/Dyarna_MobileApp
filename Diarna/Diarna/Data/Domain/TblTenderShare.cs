using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblTenderShare
    {
        public int TenderId { get; set; }
        public int? SharePercentage { get; set; }
        public int Year { get; set; }
        public int SharesId { get; set; }

        public virtual TblShare Shares { get; set; }
        public virtual TblTender Tender { get; set; }
    }
}
