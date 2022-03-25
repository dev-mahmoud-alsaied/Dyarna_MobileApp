using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblUserShare
    {
        public TblUserShare()
        {
            TblShares = new HashSet<TblShare>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int? AuthId { get; set; }

        public virtual TblAuthorization Auth { get; set; }
        public virtual ICollection<TblShare> TblShares { get; set; }
    }
}
