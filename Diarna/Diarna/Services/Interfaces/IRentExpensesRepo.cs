using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IRentExpensesRepo
    {
        Task<IEnumerable<TblRentExpense>> GetAllRentExpenses();
        Task<IEnumerable<TblRentExpense>> GetRentExpensesById(int unitId);
        Task<IEnumerable<TblRentExpense>> GetRentExpensesByDate(DateTime startDate,DateTime endDate);
        Task<TblRentExpense> AddRentExpenses(TblRentExpense tblRentExpense);
        Task<TblRentExpense> EditRentExpenses(TblRentExpense tblRentExpense);
        Task<bool> DeleteRentExpenses(TblRentExpense tblRentExpense);
        int CheckUnitAndItemExsist(int unitId,int itemId);
        int CheckUnitExsist(int unitId);
        Task<TblRentExpense> GetRentExpensesByIdAndDate(TblRentExpense tblRentExpense);
    }
}
