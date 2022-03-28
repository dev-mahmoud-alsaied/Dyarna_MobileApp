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
    public interface IItemRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblItem>> GetAllItems();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblItem>> GetAllItemsWithDetail();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblItem>> GetAllItemsWithGeneralExpenses();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblItem> GetItemById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblItem> GetItemByIdWithDetail(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblItem"></param>
        /// <returns></returns>
        Task<TblItem> AddItem(TblItem tblItem);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblItem"></param>
        /// <returns></returns>
        Task<TblItem> EditItem(TblItem tblItem);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItem(int id);
    }
}
