using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRentUserRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblRentUser>> GetAllRentUsers();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblRentUser> GetRentUserById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TblRentUser> GetRentUserByName(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<TblRentUser> GetRentUserByPhone(string phone);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentUser"></param>
        /// <returns></returns>
        Task<TblRentUser> AddRentUser(TblRentUser tblRentUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentUser"></param>
        /// <returns></returns>
        Task<TblRentUser> EditRentUser(TblRentUser tblRentUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRentUser(int id);
    }
}
