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
    public class RentExpensesRepo : IRentExpensesRepo
    {
        private readonly DiarnaContext _context;
        public RentExpensesRepo(DiarnaContext _context)
        {
            this._context = _context;
        }
        public async Task<TblRentExpense> AddRentExpenses(TblRentExpense tblRentExpense)
        {
            try
            {
                var result = await _context.TblRentExpenses.AddAsync(tblRentExpense);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteRentExpenses(TblRentExpense tblRentExpense)
        {
            try
            {
                var result = await GetRentExpensesByIdAndDate(tblRentExpense);
                if (result != null)
                {
                    _context.TblRentExpenses.Remove(result);
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

        public async Task<TblRentExpense> EditRentExpenses(TblRentExpense tblRentExpense)
        {
            try
            {
                _context.Entry(tblRentExpense).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblRentExpense;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblRentExpense>> GetAllRentExpenses()
        {
            return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item).ToListAsync();
        }

        public async Task<IEnumerable<TblRentExpense>> GetRentExpensesById(int unitId)
        {
                return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
                .Where(x => x.UnitId == unitId).ToListAsync();
        }

        public async Task<IEnumerable<TblRentExpense>> GetRentExpensesByDate(DateTime startDate, DateTime endDate)
        {
            return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
            .Where(x => x.Date >= DateTime.Parse(startDate.ToShortDateString()) && x.Date <= DateTime.Parse(endDate.ToShortDateString())).ToListAsync();
        }

        public int CheckUnitAndItemExsist(int unitId,int itemId)
        {
            var result = _context.TblRentExpenses.Where(x => x.UnitId == unitId && x.ItemId == itemId).ToList();
            return result.Count;
        }

        public int CheckUnitExsist(int unitId)
        {
            var result = _context.TblRentExpenses.Where(x => x.UnitId == unitId).ToList();
            return result.Count;
        }

        public async Task<TblRentExpense> GetRentExpensesByIdAndDate(TblRentExpense tblRentExpense)
        {
            var result = await _context.TblRentExpenses.SingleOrDefaultAsync(x => x.ItemId == tblRentExpense.ItemId
            && x.UnitId == tblRentExpense.UnitId && x.Date == DateTime.Parse(tblRentExpense.Date.ToShortDateString()));
            return result;
        }
    }
}
