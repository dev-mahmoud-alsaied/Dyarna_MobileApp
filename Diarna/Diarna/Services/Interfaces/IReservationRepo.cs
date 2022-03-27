using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IReservationRepo
    {
        Task<IEnumerable<TblReservation>> GetAllReservations();
        Task<IEnumerable< TblReservation>> GetReservationByUnitId(int unitId);
        Task<TblReservation> GetReservationByUnitIdAndDateId(int unitId, int dateId);
        Task<TblReservation> GetReservationByRentUserId(int rentId);
        Task<TblReservation> AddReservation(TblReservation tblReservation);
        Task<TblReservation> EditReservation(TblReservation tblReservation);
        Task<bool> DeleteReservation(int unitId, int dateId);
    }
}
