using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblReservationDate
    {
        public TblReservationDate()
        {
            TblReservations = new HashSet<TblReservation>();
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Id { get; set; }

        public virtual ICollection<TblReservation> TblReservations { get; set; }
    }
}
