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
    public interface IItemTypeRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblItemType>> GetAllItemTypes();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblItemType> GetItemTypeById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblItemType"></param>
        /// <returns></returns>
        Task<TblItemType> AddItemType(TblItemType tblItemType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblItemType"></param>
        /// <returns></returns>
        Task<TblItemType> EditItemType(TblItemType tblItemType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItemType(int id);
    }
}
