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
    public class UpdateUnitDataRepo : IUpdateUnitDataRepo
    {
        private readonly DiarnaContext _context;
        public UpdateUnitDataRepo(DiarnaContext _context)
        {
            this._context = _context;
        }

        public async Task<TblUnit> EditUnitData(TblUnit tblUnit)
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

        public async Task<TblUnit> GetUnitDataById(int id)
        {
            return await _context.TblUnits.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
