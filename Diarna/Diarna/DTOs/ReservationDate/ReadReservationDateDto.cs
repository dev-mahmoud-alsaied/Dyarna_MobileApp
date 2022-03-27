using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.ReservationDate
{
    public class ReadReservationDateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Id { get; set; }

    }
}
