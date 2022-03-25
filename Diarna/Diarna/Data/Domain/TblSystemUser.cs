using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblSystemUser
    {
        public TblSystemUser()
        {
            TblSystemUserAuthorizations = new HashSet<TblSystemUserAuthorization>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? SuperAdmin { get; set; }
        public int Id { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<TblSystemUserAuthorization> TblSystemUserAuthorizations { get; set; }
    }
}
