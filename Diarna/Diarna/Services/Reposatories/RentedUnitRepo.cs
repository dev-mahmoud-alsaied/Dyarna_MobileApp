using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using Diarna.Data;
using Microsoft.EntityFrameworkCore;

namespace Diarna.Services.Reposatories
{
    /// <summary>
    /// 
    /// </summary>
    public class RentedUnitRepo : IRentedUnitRepo
    {
        private readonly DiarnaContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public RentedUnitRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentedUnit"></param>
        /// <returns></returns>
        public async Task<TblRentedUnit> AddRentedUnit(TblRentedUnit tblRentedUnit)
        {
            try
            {
                var result = await _context.TblRentedUnits.AddAsync(tblRentedUnit);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRentedUnit(int id)
        {
            try
            {
                var result = await GetRentedUnitById(id);
                if (result != null)
                {
                    _context.TblRentedUnits.Remove(result);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentedUnit"></param>
        /// <returns></returns>
        public async Task<TblRentedUnit> EditRentedUnit(TblRentedUnit tblRentedUnit)
        {
            try
            {
                _context.Entry(tblRentedUnit).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblRentedUnit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TblRentedUnit>> GetAllRentedUnits()
        {
            return await _context.TblRentedUnits.Include(x => x.Unit).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblRentedUnit> GetRentedUnitById(int id)
        {
            return await _context.TblRentedUnits.Include(x => x.Unit).SingleOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public async Task<TblRentedUnit> CheckUnitExsist(int unitId)
        {
            return await _context.TblRentedUnits.FirstOrDefaultAsync(x => x.UnitId == unitId);
        }
    }
}
