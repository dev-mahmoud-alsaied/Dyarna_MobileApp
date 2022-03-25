using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblShare
    {
        public TblShare()
        {
            TblRentExpenses = new HashSet<TblRentExpense>();
            TblTenderShares = new HashSet<TblTenderShare>();
            TblUnitsShares = new HashSet<TblUnitsShare>();
        }

        public int Id { get; set; }
        public int? UserSharesId { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? UserCash { get; set; }
        public double? Percent { get; set; }
        public double? ManagePercent { get; set; }
        public decimal? UserMinProfit { get; set; }
        public decimal? AdditionProfit { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? ShareType { get; set; }
        public string Name { get; set; }

        public virtual TblUserShare UserShares { get; set; }
        public virtual ICollection<TblRentExpense> TblRentExpenses { get; set; }
        public virtual ICollection<TblTenderShare> TblTenderShares { get; set; }
        public virtual ICollection<TblUnitsShare> TblUnitsShares { get; set; }
    }
}
