using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblBuilding
    {
        public TblBuilding()
        {
            TblUnits = new HashSet<TblUnit>();
        }

        public int Id { get; set; }
        public int? VillageId { get; set; }
        public string Name { get; set; }
        public bool Elvatoer { get; set; }
        public bool SpecialGarden { get; set; }
        public bool FreeParking { get; set; }
        public bool FreeWifi { get; set; }
        public bool ReceptionDesk { get; set; }
        public bool PrivateTransport { get; set; }
        public decimal AwayFromPeach { get; set; }
        public string  Map { get; set; }
        public string  Notes { get; set; }

        public virtual TblVillage Village { get; set; }
        public virtual ICollection<TblUnit> TblUnits { get; set; }
    }
}
