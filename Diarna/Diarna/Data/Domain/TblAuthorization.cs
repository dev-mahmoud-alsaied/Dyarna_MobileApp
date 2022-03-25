using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblAuthorization
    {
        public TblAuthorization()
        {
            TblSystemUserAuthorizations = new HashSet<TblSystemUserAuthorization>();
            TblUserShares = new HashSet<TblUserShare>();
        }

        public int Id { get; set; }
        public string ScreenName { get; set; }

        public virtual ICollection<TblSystemUserAuthorization> TblSystemUserAuthorizations { get; set; }
        public virtual ICollection<TblUserShare> TblUserShares { get; set; }
    }
}
