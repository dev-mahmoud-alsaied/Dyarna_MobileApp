using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReservationDateRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblReservationDate>> GetAllReservationDates();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblReservationDate> GetReservationDateById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<TblReservationDate> GetReservationDateByStartDateAndEndDate(DateTime start, DateTime end);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblReservationDate"></param>
        /// <returns></returns>
        Task<TblReservationDate> AddReservationDate(TblReservationDate tblReservationDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblReservationDate"></param>
        /// <returns></returns>
        Task<TblReservationDate> EditReservationDate(TblReservationDate tblReservationDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteReservationDate(int id);
    }
}
