using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReservationRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblReservation>> GetAllReservations();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        Task<IEnumerable< TblReservation>> GetReservationByUnitId(int unitId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="dateId"></param>
        /// <returns></returns>
        Task<TblReservation> GetReservationByUnitIdAndDateId(int unitId, int dateId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rentId"></param>
        /// <returns></returns>
        Task<TblReservation> GetReservationByRentUserId(int rentId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblReservation"></param>
        /// <returns></returns>
        Task<TblReservation> AddReservation(TblReservation tblReservation);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblReservation"></param>
        /// <returns></returns>
        Task<TblReservation> EditReservation(TblReservation tblReservation);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="dateId"></param>
        /// <returns></returns>
        Task<bool> DeleteReservation(int unitId, int dateId);
    }
}
