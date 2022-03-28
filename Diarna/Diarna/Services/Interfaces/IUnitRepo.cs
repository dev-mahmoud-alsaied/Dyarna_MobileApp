using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblUnit>> GetAllUnits();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblUnit> GetUnitById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<TblUnit> GetUnitByName(string Name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblUnit"></param>
        /// <returns></returns>
        Task<TblUnit> AddUnit(TblUnit tblUnit);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblUnit"></param>
        /// <returns></returns>
        Task<TblUnit> EditUnit(TblUnit tblUnit);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUnit(int id);
    }
}
