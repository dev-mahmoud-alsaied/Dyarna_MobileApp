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

        public virtual TblVillage Village { get; set; }
        public virtual ICollection<TblUnit> TblUnits { get; set; }
    }
}
