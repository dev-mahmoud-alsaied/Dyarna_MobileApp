using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IItemRepo
    {
        Task<IEnumerable<TblItem>> GetAllItems();
        Task<IEnumerable<TblItem>> GetAllItemsWithDetail();
        Task<IEnumerable<TblItem>> GetAllItemsWithGeneralExpenses();
        Task<TblItem> GetItemById(int id);
        Task<TblItem> GetItemByIdWithDetail(int id);
        Task<TblItem> AddItem(TblItem tblItem);
        Task<TblItem> EditItem(TblItem tblItem);
        Task<bool> DeleteItem(int id);
    }
}
