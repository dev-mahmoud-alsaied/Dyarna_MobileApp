using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Unit
{
    public class ReadUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BuildingId { get; set; }
        public bool? SystemOwned { get; set; }
        public decimal? MinInsuranceValue { get; set; }
        public decimal? MinDepositValue { get; set; }
        public string Remarks { get; set; }
        public bool? IsValid { get; set; }
    }
}
