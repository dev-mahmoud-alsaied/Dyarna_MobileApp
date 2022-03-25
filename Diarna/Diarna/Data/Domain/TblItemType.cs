using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblItemType
    {
        public TblItemType()
        {
            TblItems = new HashSet<TblItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblItem> TblItems { get; set; }
    }
}
