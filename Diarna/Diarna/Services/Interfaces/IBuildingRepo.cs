using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBuildingRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblBuilding>> GetAllBuildings();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblBuilding> GetBuildingById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TblBuilding> GetBuildingByName(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblBuilding"></param>
        /// <returns></returns>
        Task<TblBuilding> AddBuilding(TblBuilding tblBuilding);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblBuilding"></param>
        /// <returns></returns>
        Task<TblBuilding> EditBuilding(TblBuilding tblBuilding);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteBuilding(int id);
    }
}
