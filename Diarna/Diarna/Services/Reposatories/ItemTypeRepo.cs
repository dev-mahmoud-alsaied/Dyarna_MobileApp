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
    public class ItemTypeRepo : IItemTypeRepo
    {
        private readonly DiarnaContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public ItemTypeRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblItemType"></param>
        /// <returns></returns>
        public async Task<TblItemType> AddItemType(TblItemType tblItemType)
        {
            try
            {
                var result = await _context.TblItemTypes.AddAsync(tblItemType);
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
        public async Task<bool> DeleteItemType(int id)
        {
            try
            {
                var result = await GetItemTypeById(id);
                if (result != null)
                {
                    _context.TblItemTypes.Remove(result);
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
        /// <param name="tblItemType"></param>
        /// <returns></returns>
        public async Task<TblItemType> EditItemType(TblItemType tblItemType)
        {
            try
            {
                _context.Entry(tblItemType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblItemType;
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
        public async Task<IEnumerable<TblItemType>> GetAllItemTypes()
        {
            return await _context.TblItemTypes.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblItemType> GetItemTypeById(int id)
        {
            return await _context.TblItemTypes.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
