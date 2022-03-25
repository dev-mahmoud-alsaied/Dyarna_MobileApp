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
    public class UnitRepo : IUnitRepo
    {
        private readonly DiarnaContext _context;
        public UnitRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblUnit> AddUnit(TblUnit tblUnit)
        {
            try
            {
                var result = await _context.TblUnits.AddAsync(tblUnit);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task<bool> DeleteUnit(int id)
        {
            try
            {
                var result = await GetUnitById(id);
                if (result != null)
                {
                    _context.TblUnits.Remove(result);
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

        public async Task<TblUnit> EditUnit(TblUnit tblUnit)
        {
            try
            {
                _context.Entry(tblUnit).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblUnit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblUnit>> GetAllUnits()
        {
            return await _context.TblUnits.ToListAsync();
        }

        public async Task<TblUnit> GetUnitById(int id)
        {
            return await _context.TblUnits.SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<TblUnit> GetUnitByName(string name)
        {
            return await _context.TblUnits.SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
