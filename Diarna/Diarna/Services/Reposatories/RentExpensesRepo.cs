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
        public Task<TblRentExpense> AddRentExpenses(TblRentExpense tblRentExpense)
        {
            /*try
            {
                var result = await _context.TblRentedUnits.AddAsync(tblRentedUnit);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
            throw new NotImplementedException();
        }

        public  Task<bool> DeleteRentExpenses(int id)
        {
            throw new NotImplementedException();
            /*try
            {
                var result = await GetRentExpensesById(null,null);
                if (result != null)
                {
                    _context.TblRentedUnits.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
        }

        public  Task<TblRentExpense> EditRentExpenses(TblRentExpense tblRentExpense)
        {
            throw new NotImplementedException();
            /*try
            {
                _context.Entry(tblRentedUnit).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblRentedUnit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
        }

        public async Task<IEnumerable<TblRentExpense>> GetAllRentExpenses()
        {
            return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item).ToListAsync();
        }

        public async Task<IEnumerable<TblRentExpense>> GetRentExpensesById(int unitId,int? itemId)
        {
                return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
                .Where(x => x.UnitId == unitId && x.ItemId == itemId).ToListAsync();
        }

        /*public async Task<TblRentedUnit> CheckUnitExsist(int unitId)
        {
            return await _context.TblRentedUnits.FirstOrDefaultAsync(x => x.UnitId == unitId);
        }*/
    }
}
