using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblContractingExpnse
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public double? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public int? TenderId { get; set; }

        public virtual TblItem Item { get; set; }
        public virtual TblTender Tender { get; set; }
    }
}
