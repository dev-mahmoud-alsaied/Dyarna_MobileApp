using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblRentUser
    {
        public TblRentUser()
        {
            TblReservations = new HashSet<TblReservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblReservation> TblReservations { get; set; }
    }
}
