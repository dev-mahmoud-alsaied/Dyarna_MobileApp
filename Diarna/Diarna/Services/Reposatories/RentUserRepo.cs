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
    public class RentUserRepo : IRentUserRepo
    {
        private readonly DiarnaContext _context;
        public RentUserRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblRentUser> AddRentUser(TblRentUser tblRentUser)
        {
            try
            {
                var result = await _context.TblRentUsers.AddAsync(tblRentUser);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteRentUser(int id)
        {
            try
            {
                var result = await GetRentUserById(id);
                if (result != null)
                {
                    _context.TblRentUsers.Remove(result);
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

        public async Task<TblRentUser> EditRentUser(TblRentUser tblRentUser)
        {
            try
            {
                _context.Entry(tblRentUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblRentUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblRentUser>> GetAllRentUsers()
        {
            return await _context.TblRentUsers.ToListAsync();
        }
         
        public async Task<TblRentUser> GetRentUserById(int id)
        {
            return await _context.TblRentUsers.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TblRentUser> GetRentUserByName(string name)
        {
            return await _context.TblRentUsers.SingleOrDefaultAsync(x => x.Name == name);
        }
        public async Task<TblRentUser> GetRentUserByPhone(string phone)
        {
            return await _context.TblRentUsers.SingleOrDefaultAsync(x => x.Mobile == phone);
        }
        
        
    }
}
