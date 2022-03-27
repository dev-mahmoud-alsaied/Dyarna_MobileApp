using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs
{
    public class ReadRentExpensesDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public decimal? ItemValue { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        //public int? SharesId { get; set; }
    }
}
