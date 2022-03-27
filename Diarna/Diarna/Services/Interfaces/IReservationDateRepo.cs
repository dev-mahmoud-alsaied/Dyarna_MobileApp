using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IReservationDateRepo
    {
        Task<IEnumerable<TblReservationDate>> GetAllReservationDates();
        Task<TblReservationDate> GetReservationDateById(int id);
        Task<TblReservationDate> GetReservationDateByStartDateAndEndDate(DateTime start, DateTime end);
        Task<TblReservationDate> AddReservationDate(TblReservationDate tblReservationDate);
        Task<TblReservationDate> EditReservationDate(TblReservationDate tblReservationDate);
        Task<bool> DeleteReservationDate(int id);
    }
}
