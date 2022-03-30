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
    public interface IRentShareRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblShare>> GetAllRentShares();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shareId"></param>
        /// <returns></returns>
        Task<TblShare> GetRentShareByShareId(int shareId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userShareId"></param>
        /// <returns></returns>
        Task<IEnumerable<TblShare>> GetRentShareByUserShareId(int userShareId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblShare"></param>
        /// <returns></returns>
        Task<TblShare> AddRentShare(TblShare tblShare);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblShare"></param>
        /// <returns></returns>
        Task<TblShare> EditRentShare(TblShare tblShare);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRentShare(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userShareId"></param>
        /// <returns></returns>
        Task<TblUserShare> CheckUserShareExsist(int userShareId);
    }
}
