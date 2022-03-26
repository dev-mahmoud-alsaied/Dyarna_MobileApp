using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Unit
{
    public class ReadRentedUnitDto
    {
        public int Id { get; set; }
        public DateTime? RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public string Remarks { get; set; }
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
