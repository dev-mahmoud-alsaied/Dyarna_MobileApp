using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblVillage
    {
        public TblVillage()
        {
            TblBuildings = new HashSet<TblBuilding>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<TblBuilding> TblBuildings { get; set; }
    }
}
