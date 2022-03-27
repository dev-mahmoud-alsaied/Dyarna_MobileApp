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
        Task<IEnumerable<TblRentExpense>> GetRentExpensesById(int unitId, int? itemId);
        Task<TblRentExpense> AddRentExpenses(TblRentExpense tblRentExpense);
        Task<TblRentExpense> EditRentExpenses(TblRentExpense tblRentExpense);
        Task<bool> DeleteRentExpenses(int id);
        //Task<TblRentedUnit> CheckUnitExsist(int unitId);
    }
}
