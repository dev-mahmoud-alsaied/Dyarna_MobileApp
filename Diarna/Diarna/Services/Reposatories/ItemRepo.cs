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
    public class ItemRepo : IItemRepo
    {
        private readonly DiarnaContext _context;
        public ItemRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblItem> AddItem(TblItem tblItem)
        {
            try
            {
                var result = await _context.TblItems.AddAsync(tblItem);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                var result = await GetItemById(id);
                if (result != null)
                {
                    _context.TblItems.Remove(result);
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

        public async Task<TblItem> EditItem(TblItem tblItem)
        {
            try
            {
                _context.Entry(tblItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblItem>> GetAllItems()
        {
            return await _context.TblItems.ToListAsync();
        }

        public async Task<IEnumerable<TblItem>> GetAllItemsWithDetail()
        {
            return await _context.TblItems.Include(x => x.Itemtype).ToListAsync();
        }

        public async Task<IEnumerable<TblItem>> GetAllItemsWithGeneralExpenses()
        {
            return await _context.TblItems.Where(x => x.GeneralExpenses == true).Include(x => x.Itemtype).ToListAsync();
        }

        public async Task<TblItem> GetItemById(int id)
        {
            return await _context.TblItems.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TblItem> GetItemByIdWithDetail(int id)
        {
            return await _context.TblItems.Include(x => x.Itemtype).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
