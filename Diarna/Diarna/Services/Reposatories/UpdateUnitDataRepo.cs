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
    public class UpdateUnitDataRepo : IUpdateUnitDataRepo
    {
        private readonly DiarnaContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public UpdateUnitDataRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblUnit"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblUnit> GetUnitDataById(int id)
        {
            return await _context.TblUnits.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
