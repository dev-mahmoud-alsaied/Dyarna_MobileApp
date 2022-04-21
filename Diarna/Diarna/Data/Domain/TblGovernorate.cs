using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblGovernorate
    {
        public TblGovernorate()
        {
            TblVillages = new HashSet<TblVillage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TblVillage> TblVillages { get; set; }
    }
}
