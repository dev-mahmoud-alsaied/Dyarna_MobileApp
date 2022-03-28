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
    public interface IRentedUnitRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TblRentedUnit>> GetAllRentedUnits();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblRentedUnit> GetRentedUnitById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentedUnit"></param>
        /// <returns></returns>
        Task<TblRentedUnit> AddRentedUnit(TblRentedUnit tblRentedUnit);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblRentedUnit"></param>
        /// <returns></returns>
        Task<TblRentedUnit> EditRentedUnit(TblRentedUnit tblRentedUnit);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRentedUnit(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        Task<TblRentedUnit> CheckUnitExsist(int unitId);
    }
}
