using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblSystemUserAuthorization
    {
        public int SysUserId { get; set; }
        public int AuthId { get; set; }

        public virtual TblAuthorization Auth { get; set; }
        public virtual TblSystemUser SysUser { get; set; }
    }
}
