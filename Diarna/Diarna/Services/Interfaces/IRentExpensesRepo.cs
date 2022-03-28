using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRentExpensesRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblRentExpense>> GetAllRentExpenses();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        Task<IEnumerable<TblRentExpense>> GetRentExpensesById(int unitId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<IEnumerable<TblRentExpense>> GetRentExpensesByDate(DateTime startDate,DateTime endDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentExpense"></param>
        /// <returns></returns>
        Task<TblRentExpense> AddRentExpenses(TblRentExpense tblRentExpense);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentExpense"></param>
        /// <returns></returns>
        Task<TblRentExpense> EditRentExpenses(TblRentExpense tblRentExpense);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentExpense"></param>
        /// <returns></returns>
        Task<bool> DeleteRentExpenses(TblRentExpense tblRentExpense);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        int CheckUnitAndItemExsist(int unitId,int itemId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        int CheckUnitExsist(int unitId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentExpense"></param>
        /// <returns></returns>
        Task<TblRentExpense> GetRentExpensesByIdAndDate(TblRentExpense tblRentExpense);
    }
}
