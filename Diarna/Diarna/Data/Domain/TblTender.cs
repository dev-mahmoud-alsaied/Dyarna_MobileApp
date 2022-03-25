using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblTender
    {
        public TblTender()
        {
            TblContractingExpnses = new HashSet<TblContractingExpnse>();
            TblContractingImports = new HashSet<TblContractingImport>();
            TblTenderShares = new HashSet<TblTenderShare>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TatalPrice { get; set; }
        public string Image { get; set; }

        public virtual ICollection<TblContractingExpnse> TblContractingExpnses { get; set; }
        public virtual ICollection<TblContractingImport> TblContractingImports { get; set; }
        public virtual ICollection<TblTenderShare> TblTenderShares { get; set; }
    }
}
