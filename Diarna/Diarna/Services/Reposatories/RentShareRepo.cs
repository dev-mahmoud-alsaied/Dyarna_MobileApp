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
    public class RentShareRepo : IRentShareRepo
    {
        private readonly DiarnaContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public RentShareRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblShare"></param>
        /// <returns></returns>
        public async Task<TblShare> AddRentShare(TblShare tblShare)
        {
            try
            {
                var result = await _context.TblShares.AddAsync(tblShare);
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
        public async Task<bool> DeleteRentShare(int id)
        {
            try
            {
                var result = await GetRentShareByShareId(id);
                if (result != null)
                {
                    _context.TblShares.Remove(result);
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
        /// <param name="tblShare"></param>
        /// <returns></returns>
        public async Task<TblShare> EditRentShare(TblShare tblShare)
        {
            try
            {
                _context.Entry(tblShare).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblShare;
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
        public async Task<IEnumerable<TblShare>> GetAllRentShares()
        {
            return await _context.TblShares.Include(x => x.UserShares).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TblShare>> GetRentShareByUserShareId(int id)
        {
            return await _context.TblShares.Include(x => x.UserShares).Where(x => x.UserSharesId == id).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblShare> GetRentShareByShareId(int id)
        {
            return await _context.TblShares.Include(x => x.UserShares).SingleOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userShareId"></param>
        /// <returns></returns>
        public async Task<TblUserShare> CheckUserShareExsist(int userShareId)
        {
            return await _context.TblUserShares.FirstOrDefaultAsync(x => x.Id == userShareId);
        }
    }
}
