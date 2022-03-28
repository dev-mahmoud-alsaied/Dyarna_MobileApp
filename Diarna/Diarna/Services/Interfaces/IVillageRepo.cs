using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVillageRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblVillage>> GetAllVillages();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblVillage> GetVillageById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TblVillage> GetVillageByName(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblVillage"></param>
        /// <returns></returns>
        Task<TblVillage> AddVillage(TblVillage tblVillage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblVillage"></param>
        /// <returns></returns>
        Task<TblVillage> EditVillage(TblVillage tblVillage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteVillage(int id);
    }
}
