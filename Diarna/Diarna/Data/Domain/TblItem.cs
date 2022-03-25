using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblItem
    {
        public TblItem()
        {
            TblContractingExpnses = new HashSet<TblContractingExpnse>();
            TblContractingImports = new HashSet<TblContractingImport>();
            TblRentExpenses = new HashSet<TblRentExpense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool GeneralExpenses { get; set; }
        public int? ItemtypeId { get; set; }

        public virtual TblItemType Itemtype { get; set; }
        public virtual ICollection<TblContractingExpnse> TblContractingExpnses { get; set; }
        public virtual ICollection<TblContractingImport> TblContractingImports { get; set; }
        public virtual ICollection<TblRentExpense> TblRentExpenses { get; set; }
    }
}
