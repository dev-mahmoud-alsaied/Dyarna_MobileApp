using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IItemTypeRepo
    {
        Task<IEnumerable<TblItemType>> GetAllItemTypes();
        Task<TblItemType> GetItemTypeById(int id);
        Task<TblItemType> AddItemType(TblItemType tblItemType);
        Task<TblItemType> EditItemType(TblItemType tblItemType);
        Task<bool> DeleteItemType(int id);
    }
}
