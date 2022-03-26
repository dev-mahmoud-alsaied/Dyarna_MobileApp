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
    public class VillageRepo : IVillageRepo
    {
        private readonly DiarnaContext _context;
        public VillageRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblVillage> AddVillage(TblVillage tblVillage)
        {
            try
            {
                var result = await _context.TblVillages.AddAsync(tblVillage);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVillage(int id)
        {
            try
            {
                var result = await GetVillageById(id);
                if (result != null)
                {
                    _context.TblVillages.Remove(result);
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

        public async Task<TblVillage> EditVillage(TblVillage tblVillage)
        {
            try
            {
                _context.Entry(tblVillage).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblVillage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblVillage>> GetAllVillages()
        {
            return await _context.TblVillages.ToListAsync();
        }

        public async Task<TblVillage> GetVillageById(int id)
        {
            return await _context.TblVillages.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TblVillage> GetVillageByName(string name)
        {
            return await _context.TblVillages.SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
