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
    public class BuildingRepo : IBuildingRepo
    {
        private readonly DiarnaContext _context;
        public BuildingRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblBuilding> AddBuilding(TblBuilding tblBuilding)
        {
            try
            {
                var result = await _context.TblBuildings.AddAsync(tblBuilding);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBuilding(int id)
        {
            try
            {
                var result = await GetBuildingById (id);
                if (result != null)
                {
                    _context.TblBuildings.Remove(result);
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

        public async Task<TblBuilding> EditBuilding(TblBuilding tblBuilding)
        {
            try
            {
                _context.Entry(tblBuilding).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblBuilding;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblBuilding>> GetAllBuildings()
        {
            return await _context.TblBuildings.ToListAsync();
        }
         
        public async Task<TblBuilding> GetBuildingById(int id)
        {
            return await _context.TblBuildings.SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<TblBuilding> GetBuildingByName(string name)
        {
            return await _context.TblBuildings.SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
