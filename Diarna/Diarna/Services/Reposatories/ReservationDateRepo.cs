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
    public class ReservationDateRepo : IReservationDateRepo
    {
        private readonly DiarnaContext _context;
        public ReservationDateRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblReservationDate> AddReservationDate(TblReservationDate tblReservationDate)
        {
            try
            {
                var result = await _context.TblReservationDates.AddAsync(tblReservationDate);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteReservationDate(int id)
        {
            try
            {
                var result = await GetReservationDateById (id);
                if (result != null)
                {
                    _context.TblReservationDates.Remove(result);
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

        public async Task<TblReservationDate> EditReservationDate(TblReservationDate tblReservationDate)
        {
            try
            {
                _context.Entry(tblReservationDate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblReservationDate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblReservationDate>> GetAllReservationDates()
        {
            return await _context.TblReservationDates.ToListAsync();
        }
         
        public async Task<TblReservationDate> GetReservationDateById(int id)
        {
            return await _context.TblReservationDates.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TblReservationDate> GetReservationDateByStartDateAndEndDate(DateTime start, DateTime end)
        {
            return await _context.TblReservationDates.SingleOrDefaultAsync(x => x.StartDate == start && x.EndDate == end);
        }
        
     
    }
}
