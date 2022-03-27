using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data;
using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diarna.Services.Reposatories
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly DiarnaContext _context;
        public ReservationRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblReservation> AddReservation(TblReservation tblReservation)
        {
            try
            {
                var result = await _context.TblReservations.AddAsync(tblReservation);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteReservation(int unitId, int dateId)
        {
            try
            {
                var result = await GetReservationByUnitIdAndDateId(unitId, dateId);
                if (result != null)
                {
                    _context.TblReservations.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblReservation> EditReservation(TblReservation tblReservation)
        {
            try
            {
                _context.Entry(tblReservation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblReservation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservations()
        {
            return await _context.TblReservations.ToListAsync();
        }
         
        public async Task<IEnumerable< TblReservation>> GetReservationByUnitId(int unitId)
        {
            return await _context.TblReservations.Where(x => x.UnitId == unitId).ToListAsync();
        }
        
        public async Task<TblReservation> GetReservationByRentUserId(int rentId)
        {
            return await _context.TblReservations.SingleOrDefaultAsync(x =>  x.RentUserId == rentId );
        }
        public async Task<TblReservation> GetReservationByUnitIdAndDateId(int unitId, int dateId)
        {
            return await _context.TblReservations.SingleOrDefaultAsync(x =>  x.UnitId == unitId && x.DateId == dateId);
        }
    }
}
